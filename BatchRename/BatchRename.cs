namespace BatchRename
{
    public partial class BatchRename : Form
    {
        private readonly List<string> fileNames = new();

        private static readonly string[] reservedNames =
        [
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
        ];

        private string[] plannedNewNames = [];
        private string[] plannedNewBases = [];

        private readonly List<(string OldPath, string NewPath)> lastRenames = new();

        public BatchRename()
        {
            InitializeComponent();

            positionBox.SelectedIndex = 0;

            fileGrid.AutoGenerateColumns = false;
            fileGrid.Columns.Add("folder", "所在資料夾");
            fileGrid.Columns.Add("original", "原檔名");
            fileGrid.Columns.Add("renamed", "新檔名");
            fileGrid.Columns.Add("status", "狀態");
            fileGrid.ReadOnly = true;
            fileGrid.AllowUserToAddRows = false;
            fileGrid.AllowUserToDeleteRows = false;
            fileGrid.RowHeadersVisible = false;
            fileGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            fileGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "選擇要改名的資料夾",
                UseDescriptionForTitle = true
            };

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            folderBox.Text = dialog.SelectedPath;
            ShowFiles(dialog.SelectedPath);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(folderBox.Text))
                ShowFiles(folderBox.Text);
            else
                MessageBox.Show(this, "找不到這個資料夾。", "批次改檔名");
        }

        private void extensionBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(folderBox.Text))
                ShowFiles(folderBox.Text);
        }

        private void includeSubfoldersBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(folderBox.Text))
                ShowFiles(folderBox.Text);
        }

        private void ShowFiles(string folder)
        {
            fileNames.Clear();

            EnumerationOptions options = new()
            {
                RecurseSubdirectories = includeSubfoldersBox.Checked,
                IgnoreInaccessible = true
            };

            foreach (string path in Directory.EnumerateFiles(folder, "*", options))
            {
                string relative = Path.GetRelativePath(folder, path);
                string fileOnly = Path.GetFileName(relative);

                if (fileOnly.StartsWith(".rename-", StringComparison.OrdinalIgnoreCase)
                    && fileOnly.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (!ExtensionAllowed(fileOnly))
                    continue;

                fileNames.Add(relative);
            }

            fileNames.Sort(StringComparer.OrdinalIgnoreCase);
            UpdatePreview();
        }

        private bool ExtensionAllowed(string fileName)
        {
            string text = extensionBox.Text.Trim();
            if (text.Length == 0)
                return true;

            string[] parts = text.Split(
                [',', ';', ' ', '，', '；'],
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            string extension = Path.GetExtension(fileName);
            foreach (string part in parts)
            {
                string expected = part.StartsWith('.') ? part : "." + part;
                if (extension.Equals(expected, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private void UpdatePreview()
        {
            fileGrid.Rows.Clear();
            string find = findBox.Text;
            string replace = replaceBox.Text;
            string prefix = prefixBox.Text;
            string suffix = suffixBox.Text;

            string[] newNames = new string[fileNames.Count];
            string[] newBases = new string[fileNames.Count];

            for (int index = 0; index < fileNames.Count; index++)
            {
                string relative = fileNames[index];
                string directory = Path.GetDirectoryName(relative) ?? "";
                string name = Path.GetFileName(relative);
                string baseName = Path.GetFileNameWithoutExtension(name);
                string extension = Path.GetExtension(name);

                if (find.Length > 0)
                {
                    if (ignoreCaseBox.Checked)
                        baseName = baseName.Replace(find, replace, StringComparison.OrdinalIgnoreCase);
                    else
                        baseName = baseName.Replace(find, replace, StringComparison.Ordinal);
                }

                if (removeOriginalBox.Checked)
                    baseName = "";

                string newBase = prefix + baseName + suffix;

                if (addNumberBox.Checked)
                {
                    int number = (int)startNumberBox.Value + index;
                    string numberText = number.ToString().PadLeft((int)digitsBox.Value, '0');
                    bool numberAtStart = positionBox.SelectedIndex == 1;

                    if (newBase.Length == 0)
                        newBase = numberText;
                    else if (numberAtStart)
                        newBase = numberText + separatorBox.Text + newBase;
                    else
                        newBase = newBase + separatorBox.Text + numberText;
                }

                string newFileName = newBase + extension;
                newBases[index] = newBase;
                newNames[index] = directory.Length == 0
                    ? newFileName
                    : Path.Combine(directory, newFileName);
            }

            plannedNewNames = newNames;
            plannedNewBases = newBases;

            int unchanged = 0;
            int ready = 0;
            int problems = 0;

            for (int index = 0; index < fileNames.Count; index++)
            {
                string relative = fileNames[index];
                string newName = newNames[index];

                if (newName == relative)
                {
                    unchanged++;

                    if (!hideUnchangedBox.Checked)
                        AddPreviewRow(relative, newName, "未變更");

                    continue;
                }

                string problem = NameProblem(Path.GetFileName(newName), newBases[index]);
                if (problem.Length == 0)
                    problem = ConflictProblem(newNames, index);

                if (problem.Length > 0)
                {
                    problems++;
                    AddPreviewRow(relative, newName, problem);
                }
                else
                {
                    ready++;
                    AddPreviewRow(relative, newName, "可改名");
                }
            }

            summaryLabel.Text =
                $"共 {fileNames.Count} 個檔案，可改名 {ready}，未變更 {unchanged}，有問題 {problems}。";
        }

        private string NameProblem(string newName, string newBase)
        {
            if (string.IsNullOrWhiteSpace(newBase))
                return "名稱是空的";

            if (newName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                return "含有不允許的字元";

            if (newName.EndsWith(' ') || newName.EndsWith('.'))
                return "結尾不能是空白或句點";

            string reserved = newBase.TrimEnd(' ', '.');
            foreach (string blocked in reservedNames)
            {
                if (reserved.Equals(blocked, StringComparison.OrdinalIgnoreCase))
                    return "Windows 保留名稱";
            }

            if (newName.Length > 255)
                return "檔名太長";

            return "";
        }

        private string ConflictProblem(string[] newNames, int index)
        {
            string newName = newNames[index];
            int movers = 0;

            for (int i = 0; i < newNames.Length; i++)
            {
                if (newNames[i] == fileNames[i])
                    continue;

                if (NameProblem(
                        Path.GetFileName(newNames[i]),
                        Path.GetFileNameWithoutExtension(newNames[i])).Length > 0)
                    continue;

                if (newNames[i].Equals(newName, StringComparison.OrdinalIgnoreCase))
                    movers++;
            }

            if (movers > 1)
                return "和其他檔案的新名稱衝突";

            for (int i = 0; i < fileNames.Count; i++)
            {
                if (!fileNames[i].Equals(newName, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (newNames[i] == fileNames[i])
                    return "目標已經存在";
            }

            return "";
        }

        private void AddPreviewRow(string oldRelative, string newRelative, string status)
        {
            string directory = Path.GetDirectoryName(oldRelative) ?? "";
            string folderText = directory.Length == 0 ? "（這個資料夾）" : directory;
            fileGrid.Rows.Add(
                folderText,
                Path.GetFileName(oldRelative),
                Path.GetFileName(newRelative),
                status);
        }

        private void prefixBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void suffixBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void findBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void replaceBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void ignoreCaseBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void addNumberBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void startNumberBox_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void digitsBox_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void separatorBox_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void positionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void removeOriginalBox_CheckedChanged(object sender, EventArgs e)
        {
            bool keepOriginal = !removeOriginalBox.Checked;
            findBox.Enabled = keepOriginal;
            replaceBox.Enabled = keepOriginal;
            ignoreCaseBox.Enabled = keepOriginal;

            UpdatePreview();
        }

        private void hideUnchangedBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            UpdatePreview();

            int ready = 0;
            for (int index = 0; index < fileNames.Count; index++)
            {
                if (CanRename(index))
                    ready++;
            }

            if (ready == 0)
            {
                MessageBox.Show(this, "沒有需要改名的檔案。", "批次改檔名");
                return;
            }

            DialogResult answer = MessageBox.Show(
                this,
                $"即將修改 {ready} 個檔名。",
                "批次改檔名",
                MessageBoxButtons.OKCancel);

            if (answer != DialogResult.OK)
                return;

            string folder = folderBox.Text;
            lastRenames.Clear();

            for (int index = 0; index < fileNames.Count; index++)
            {
                if (!CanRename(index))
                    continue;

                string fromPath = Path.Combine(folder, fileNames[index]);
                string toPath = Path.Combine(folder, plannedNewNames[index]);

                try
                {
                    MoveViaTemp(fromPath, toPath);
                    lastRenames.Add((fromPath, toPath));
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, $"無法修改「{fileNames[index]}」。{ex.Message}", "批次改檔名");
                    break;
                }
            }

            undoButton.Enabled = lastRenames.Count > 0;
            ShowFiles(folder);
        }

        private bool CanRename(int index)
        {
            if (plannedNewNames.Length != fileNames.Count)
                return false;

            if (plannedNewNames[index] == fileNames[index])
                return false;

            if (NameProblem(Path.GetFileName(plannedNewNames[index]), plannedNewBases[index]).Length > 0)
                return false;

            if (ConflictProblem(plannedNewNames, index).Length > 0)
                return false;

            return true;
        }

        private void MoveViaTemp(string fromPath, string toPath)
        {
            string directory = Path.GetDirectoryName(fromPath) ?? "";
            string tempPath = Path.Combine(directory, ".rename-" + Guid.NewGuid().ToString("N") + ".tmp");

            File.Move(fromPath, tempPath);
            try
            {
                File.Move(tempPath, toPath);
            }
            catch
            {
                File.Move(tempPath, fromPath);
                throw;
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (lastRenames.Count == 0)
                return;

            DialogResult answer = MessageBox.Show(
                this,
                $"要把剛才的 {lastRenames.Count} 個檔名改回去嗎？",
                "批次改檔名",
                MessageBoxButtons.OKCancel);

            if (answer != DialogResult.OK)
                return;

            for (int i = lastRenames.Count - 1; i >= 0; i--)
            {
                try
                {
                    MoveViaTemp(lastRenames[i].NewPath, lastRenames[i].OldPath);
                    lastRenames.RemoveAt(i);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, $"無法復原。{ex.Message}", "批次改檔名");
                    break;
                }
            }

            undoButton.Enabled = lastRenames.Count > 0;

            if (Directory.Exists(folderBox.Text))
                ShowFiles(folderBox.Text);
        }
    }
}