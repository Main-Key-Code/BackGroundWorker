using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackGroundWorker_Test
{
    public partial class Form1 : Form
    {
        BackgroundWorker _worker = null;

        public Form1()
        {
            InitializeComponent();

            //폼 Load 이벤트
            this.Load += FormLoad_Event;

            //버튼 클릭 이벤트
            uiBtn_Create.Click += uiBtn_Create_Click;

            //폼 Close 이벤트
            this.FormClosing += FormClosing_Event;
        }

        /// <summary>
        /// 폼 Load 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormLoad_Event(object sender, EventArgs e)
        {
            //백그라운드 객체 생성 및 스레드 시작
            InitBackgroundWorker();
        }

        /// <summary>
        /// 버튼 클릭 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void uiBtn_Create_Click(object sender, EventArgs e)
        {
            //작업 쓰레드가 Busy(즉, 실행중이 아닌상태) 라면
            if (_worker.IsBusy != true)
            {
                uiPrg_FileCreate.Maximum = RollCount;
                //비동기로 실행
                _worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 백그라운드 스레드 생성 및 이벤트 선언
        /// </summary>
        public void InitBackgroundWorker()
        {
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerComplete);
        }

        int RollCount = 10000;

        /// <summary>
        /// 작업 쓰레드가 실제로 하는 일
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string tmpDir = @"C:\Temp\Create_{0}";

            int cnt = 0;
            int pct = 0;

            try
            {
                for (int idx = 1; idx <= RollCount; idx++)
                {
                    //이미 파일이 있다면
                    if (Directory.Exists(tmpDir.Replace("{0}", idx.ToString())))
                    {
                        //해당 파일 지우고
                        Directory.Delete(tmpDir.Replace("{0}", idx.ToString()));
                    }

                    //다시 생성
                    Directory.CreateDirectory(tmpDir.Replace("{0}", idx.ToString()));

                    //pct = ((++cnt * 100) / idx);
                    pct = idx;

                    _worker.ReportProgress(pct);
                }
            }
            catch { }
        }

        /// <summary>
        /// Progress 리포트 - UI 쓰레드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.uiPrg_FileCreate.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// 작업 완료 - UI 쓰레드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Worker_RunWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //Error 체크
            if (e.Error != null)
            {
                string msg = string.Format("Errpr : {0}", e.Error.Message);
                MessageBox.Show(msg);
                return;
            }
            else
            {
                string msg = string.Format("파일 생성 성공");
                MessageBox.Show(msg);
            }
        }

        /// <summary>
        /// 폼이 닫히면
        /// 실행중이던 BackGroundWorker 스레드 종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FormClosing_Event(object sender, EventArgs e)
        {
            //_worker 객체가 생성된게 있다면
            if (_worker != null)
            {
                //해당 스레드 객체가 Busy 상태이면
                if (_worker.IsBusy)
                {
                    //스레드 취소
                    _worker.CancelAsync();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"테스트~!");
        }
    }
}
