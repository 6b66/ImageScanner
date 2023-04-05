using System.Diagnostics;
using System.IO;

namespace ImageScanner
{
    public partial class Form1 : Form
    {
        private static bool running = false;

        public Form1()
        {
            InitializeComponent();

            // ���U���g�O���b�h�̐ݒ�
            resultGrid.ColumnCount = 1;
            resultGrid.Columns[0].HeaderText = "�t�@�C����";

            // �v���O���X�o�[�̐ݒ�
            progressBar.Minimum = 0;

            // �摜�v���r���[�ݒ�
            imagePreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // �Q�ƃ{�^���������̃C�x���g
        private void refBtn_Click(object sender, EventArgs e)
        {
            // �t�@�C���I���_�C�A���O���J��
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // �I�����ꂽ�l���p�X���͗��ɓ����
                string selectedPath = folderBrowserDialog1.SelectedPath;
                refBox.Text = selectedPath;
            }
        }

        // �����{�^���������̃C�x���g
        private async void searchBtn_Click(object sender, EventArgs e)
        {
            string rootPath = refBox.Text;
            string targetString = searchBox.Text;
            bool caseSensitive = caseSensitive_CheckBox.Checked;
            bool useRegex = useRegex_CheckBox.Checked;

            var imageFileList = GetAllImageFilePath(rootPath);

            running = !running;
            if (imageFileList.Any() && running)
            {
                resultGrid.Rows.Clear();
                progressBar.Maximum = imageFileList.Count - 1;
                // �摜�������J�n
                searchBtn.Text = "�L�����Z��";
                statusLabel.Text = "���: ������";
                for (int i = 0; i < imageFileList.Count && running; i++)
                {
                    var imageFile = imageFileList[i];
                    var result = await ImageScanner.RecognizeAsync(imageFile, targetString, caseSensitive, useRegex);
                    if (result)
                    {
                        resultGrid.Rows.Add(imageFile);
                    }
                    progressBar.Value = i;
                };
                statusLabel.Text = "���: ����";
                searchBtn.Text = "����";
                running = false;
            }
            else if (!running)
            {
                statusLabel.Text = "���: �ҋ@";
                searchBtn.Text = "����";
            }
        }

        // �p�X�Ɋ܂܂�邷�ׂĂ�png�t�@�C���p�X���擾
        private List<string> GetAllImageFilePath(string rootPath)
        {
            return Directory.GetFiles(rootPath, "*.png").ToList();
        }

        // �������ʂ̗v�f���N���b�N�����Ƃ�
        private void resultGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            imagePreview.ImageLocation = resultGrid[e.ColumnIndex, e.RowIndex].Value as string;
        }

        private void imagePreview_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(imagePreview.ImageLocation);
            startInfo.Verb = "edit";
            Process.Start(startInfo);
        }
    }
}