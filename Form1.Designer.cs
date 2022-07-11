
namespace BackGroundWorker_Test
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiBtn_Create = new System.Windows.Forms.Button();
            this.uiPrg_FileCreate = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uiBtn_Create
            // 
            this.uiBtn_Create.Location = new System.Drawing.Point(12, 26);
            this.uiBtn_Create.Name = "uiBtn_Create";
            this.uiBtn_Create.Size = new System.Drawing.Size(776, 171);
            this.uiBtn_Create.TabIndex = 0;
            this.uiBtn_Create.Text = "Run";
            this.uiBtn_Create.UseVisualStyleBackColor = true;
            this.uiBtn_Create.Click += new System.EventHandler(this.uiBtn_Create_Click);
            // 
            // uiPrg_FileCreate
            // 
            this.uiPrg_FileCreate.Location = new System.Drawing.Point(12, 224);
            this.uiPrg_FileCreate.Name = "uiPrg_FileCreate";
            this.uiPrg_FileCreate.Size = new System.Drawing.Size(776, 23);
            this.uiPrg_FileCreate.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 279);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uiPrg_FileCreate);
            this.Controls.Add(this.uiBtn_Create);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uiBtn_Create;
        private System.Windows.Forms.ProgressBar uiPrg_FileCreate;
        private System.Windows.Forms.Button button1;
    }
}

