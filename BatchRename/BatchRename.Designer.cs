namespace BatchRename
{
    partial class BatchRename
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            folderBox = new TextBox();
            browseButton = new Button();
            refreshButton = new Button();
            includeSubfoldersBox = new CheckBox();
            label2 = new Label();
            extensionBox = new TextBox();
            label3 = new Label();
            prefixBox = new TextBox();
            label4 = new Label();
            suffixBox = new TextBox();
            removeOriginalBox = new CheckBox();
            label5 = new Label();
            findBox = new TextBox();
            label6 = new Label();
            replaceBox = new TextBox();
            ignoreCaseBox = new CheckBox();
            addNumberBox = new CheckBox();
            startNumberBoxLabel = new Label();
            startNumberBox = new NumericUpDown();
            label7 = new Label();
            digitsBox = new NumericUpDown();
            label8 = new Label();
            separatorBox = new TextBox();
            positionBox = new ComboBox();
            fileGrid = new DataGridView();
            hideUnchangedBox = new CheckBox();
            summaryLabel = new Label();
            undoButton = new Button();
            renameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)startNumberBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)digitsBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "資料夾";
            // 
            // folderBox
            // 
            folderBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            folderBox.Location = new Point(61, 9);
            folderBox.Name = "folderBox";
            folderBox.Size = new Size(449, 23);
            folderBox.TabIndex = 1;
            // 
            // browseButton
            // 
            browseButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            browseButton.Location = new Point(516, 9);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 23);
            browseButton.TabIndex = 2;
            browseButton.Text = "瀏覽...";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshButton.Location = new Point(597, 9);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(75, 23);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "重新整理";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // includeSubfoldersBox
            // 
            includeSubfoldersBox.AutoSize = true;
            includeSubfoldersBox.Location = new Point(12, 45);
            includeSubfoldersBox.Name = "includeSubfoldersBox";
            includeSubfoldersBox.Size = new Size(98, 19);
            includeSubfoldersBox.TabIndex = 4;
            includeSubfoldersBox.Text = "包含子資料夾";
            includeSubfoldersBox.UseVisualStyleBackColor = true;
            includeSubfoldersBox.CheckedChanged += includeSubfoldersBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(138, 47);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 5;
            label2.Text = "副檔名";
            // 
            // extensionBox
            // 
            extensionBox.Location = new Point(187, 43);
            extensionBox.Name = "extensionBox";
            extensionBox.Size = new Size(100, 23);
            extensionBox.TabIndex = 6;
            extensionBox.TextChanged += extensionBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 7;
            label3.Text = "前綴";
            // 
            // prefixBox
            // 
            prefixBox.Location = new Point(49, 77);
            prefixBox.Name = "prefixBox";
            prefixBox.Size = new Size(100, 23);
            prefixBox.TabIndex = 8;
            prefixBox.TextChanged += prefixBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 81);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 9;
            label4.Text = "後綴";
            // 
            // suffixBox
            // 
            suffixBox.Location = new Point(213, 77);
            suffixBox.Name = "suffixBox";
            suffixBox.Size = new Size(100, 23);
            suffixBox.TabIndex = 10;
            suffixBox.TextChanged += suffixBox_TextChanged;
            // 
            // removeOriginalBox
            // 
            removeOriginalBox.AutoSize = true;
            removeOriginalBox.Location = new Point(329, 79);
            removeOriginalBox.Name = "removeOriginalBox";
            removeOriginalBox.Size = new Size(86, 19);
            removeOriginalBox.TabIndex = 11;
            removeOriginalBox.Text = "移除原檔名";
            removeOriginalBox.UseVisualStyleBackColor = true;
            removeOriginalBox.CheckedChanged += removeOriginalBox_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 115);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 12;
            label5.Text = "尋找";
            // 
            // findBox
            // 
            findBox.Location = new Point(49, 111);
            findBox.Name = "findBox";
            findBox.Size = new Size(100, 23);
            findBox.TabIndex = 13;
            findBox.TextChanged += findBox_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(164, 115);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 14;
            label6.Text = "取代為";
            // 
            // replaceBox
            // 
            replaceBox.Location = new Point(213, 111);
            replaceBox.Name = "replaceBox";
            replaceBox.Size = new Size(100, 23);
            replaceBox.TabIndex = 15;
            replaceBox.TextChanged += replaceBox_TextChanged;
            // 
            // ignoreCaseBox
            // 
            ignoreCaseBox.AutoSize = true;
            ignoreCaseBox.Location = new Point(329, 113);
            ignoreCaseBox.Name = "ignoreCaseBox";
            ignoreCaseBox.Size = new Size(86, 19);
            ignoreCaseBox.TabIndex = 16;
            ignoreCaseBox.Text = "忽略大小寫";
            ignoreCaseBox.UseVisualStyleBackColor = true;
            ignoreCaseBox.CheckedChanged += ignoreCaseBox_CheckedChanged;
            // 
            // addNumberBox
            // 
            addNumberBox.AutoSize = true;
            addNumberBox.Location = new Point(12, 149);
            addNumberBox.Name = "addNumberBox";
            addNumberBox.Size = new Size(74, 19);
            addNumberBox.TabIndex = 17;
            addNumberBox.Text = "加上序號";
            addNumberBox.UseVisualStyleBackColor = true;
            addNumberBox.CheckedChanged += addNumberBox_CheckedChanged;
            // 
            // startNumberBoxLabel
            // 
            startNumberBoxLabel.AutoSize = true;
            startNumberBoxLabel.Location = new Point(111, 151);
            startNumberBoxLabel.Name = "startNumberBoxLabel";
            startNumberBoxLabel.Size = new Size(31, 15);
            startNumberBoxLabel.TabIndex = 18;
            startNumberBoxLabel.Text = "起始";
            // 
            // startNumberBox
            // 
            startNumberBox.Location = new Point(153, 147);
            startNumberBox.Name = "startNumberBox";
            startNumberBox.Size = new Size(60, 23);
            startNumberBox.TabIndex = 19;
            startNumberBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
            startNumberBox.ValueChanged += startNumberBox_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(224, 151);
            label7.Name = "label7";
            label7.Size = new Size(31, 15);
            label7.TabIndex = 20;
            label7.Text = "位數";
            // 
            // digitsBox
            // 
            digitsBox.Location = new Point(266, 147);
            digitsBox.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            digitsBox.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            digitsBox.Name = "digitsBox";
            digitsBox.Size = new Size(60, 23);
            digitsBox.TabIndex = 21;
            digitsBox.Value = new decimal(new int[] { 3, 0, 0, 0 });
            digitsBox.ValueChanged += digitsBox_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(337, 151);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 22;
            label8.Text = "分隔";
            // 
            // separatorBox
            // 
            separatorBox.Location = new Point(379, 147);
            separatorBox.Name = "separatorBox";
            separatorBox.Size = new Size(60, 23);
            separatorBox.TabIndex = 23;
            separatorBox.Text = "_";
            separatorBox.TextChanged += separatorBox_TextChanged;
            // 
            // positionBox
            // 
            positionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            positionBox.FormattingEnabled = true;
            positionBox.Items.AddRange(new object[] { "名稱後面", "名稱前面" });
            positionBox.Location = new Point(450, 147);
            positionBox.Name = "positionBox";
            positionBox.Size = new Size(121, 23);
            positionBox.TabIndex = 24;
            positionBox.SelectedIndexChanged += positionBox_SelectedIndexChanged;
            // 
            // fileGrid
            // 
            fileGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fileGrid.Location = new Point(12, 185);
            fileGrid.Name = "fileGrid";
            fileGrid.Size = new Size(660, 240);
            fileGrid.TabIndex = 25;
            // 
            // hideUnchangedBox
            // 
            hideUnchangedBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            hideUnchangedBox.AutoSize = true;
            hideUnchangedBox.Location = new Point(12, 435);
            hideUnchangedBox.Name = "hideUnchangedBox";
            hideUnchangedBox.Size = new Size(122, 19);
            hideUnchangedBox.TabIndex = 26;
            hideUnchangedBox.Text = "隱藏未變更的檔案";
            hideUnchangedBox.UseVisualStyleBackColor = true;
            hideUnchangedBox.CheckedChanged += hideUnchangedBox_CheckedChanged;
            // 
            // summaryLabel
            // 
            summaryLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            summaryLabel.AutoSize = true;
            summaryLabel.Location = new Point(153, 435);
            summaryLabel.Name = "summaryLabel";
            summaryLabel.Size = new Size(103, 15);
            summaryLabel.TabIndex = 27;
            summaryLabel.Text = "統計會顯示在這裡";
            // 
            // undoButton
            // 
            undoButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            undoButton.Enabled = false;
            undoButton.Location = new Point(516, 431);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(75, 23);
            undoButton.TabIndex = 28;
            undoButton.Text = "復原上一次";
            undoButton.UseVisualStyleBackColor = true;
            undoButton.Click += undoButton_Click;
            // 
            // renameButton
            // 
            renameButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            renameButton.Location = new Point(597, 431);
            renameButton.Name = "renameButton";
            renameButton.Size = new Size(75, 23);
            renameButton.TabIndex = 29;
            renameButton.Text = "執行改名";
            renameButton.UseVisualStyleBackColor = true;
            renameButton.Click += renameButton_Click;
            // 
            // BatchRename
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(renameButton);
            Controls.Add(undoButton);
            Controls.Add(summaryLabel);
            Controls.Add(hideUnchangedBox);
            Controls.Add(fileGrid);
            Controls.Add(positionBox);
            Controls.Add(separatorBox);
            Controls.Add(label8);
            Controls.Add(digitsBox);
            Controls.Add(label7);
            Controls.Add(startNumberBox);
            Controls.Add(startNumberBoxLabel);
            Controls.Add(addNumberBox);
            Controls.Add(ignoreCaseBox);
            Controls.Add(replaceBox);
            Controls.Add(label6);
            Controls.Add(findBox);
            Controls.Add(label5);
            Controls.Add(removeOriginalBox);
            Controls.Add(suffixBox);
            Controls.Add(label4);
            Controls.Add(prefixBox);
            Controls.Add(label3);
            Controls.Add(extensionBox);
            Controls.Add(label2);
            Controls.Add(includeSubfoldersBox);
            Controls.Add(refreshButton);
            Controls.Add(browseButton);
            Controls.Add(folderBox);
            Controls.Add(label1);
            MinimumSize = new Size(700, 500);
            Name = "BatchRename";
            Text = "批次改檔名";
            ((System.ComponentModel.ISupportInitialize)startNumberBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)digitsBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox folderBox;
        private Button browseButton;
        private Button refreshButton;
        private CheckBox includeSubfoldersBox;
        private Label label2;
        private TextBox extensionBox;
        private Label label3;
        private TextBox prefixBox;
        private Label label4;
        private TextBox suffixBox;
        private CheckBox removeOriginalBox;
        private Label label5;
        private TextBox findBox;
        private Label label6;
        private TextBox replaceBox;
        private CheckBox ignoreCaseBox;
        private CheckBox addNumberBox;
        private Label startNumberBoxLabel;
        private NumericUpDown startNumberBox;
        private Label label7;
        private NumericUpDown digitsBox;
        private Label label8;
        private TextBox separatorBox;
        private ComboBox positionBox;
        private DataGridView fileGrid;
        private CheckBox hideUnchangedBox;
        private Label summaryLabel;
        private Button undoButton;
        private Button renameButton;
    }
}
