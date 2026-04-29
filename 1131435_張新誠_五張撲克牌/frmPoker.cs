using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1131435_張新誠_五張撲克牌
{
    public partial class frmPoker: Form
    {
        PictureBox[] pic = new PictureBox[5];
        int totalMoney = 1000000; // 初始總資金 100 萬
        int currentBet = 0;       // 記錄當前局的下注金額
        public frmPoker()
        {
            InitializeComponent();
            InitializePoker();
        }
        private void InitializePoker()
        {
            // 動態產生5張牌
            for (int i = 0; i < 5; i++)
            {
                pic[i] = new PictureBox();
                pic[i].Image = GetImage("back");
                pic[i].Name = "pic" + i;
                pic[i].SizeMode = PictureBoxSizeMode.AutoSize;
                pic[i].Top = 30;
                pic[i].Left = 10 + ((pic[i].Width + 10) * i);
                pic[i].Visible = true;
                pic[i].Enabled = false;
                pic[i].Tag = "back";
                // 將 pic 丟至到 grpPorker 內
                this.grpPoker.Controls.Add(pic[i]);
                pic[i].MouseClick += new MouseEventHandler(pic_Click);
            }
        }
        private Image GetImage(string name)
        {
            return Properties.Resources.ResourceManager
            .GetObject(name) as Image;
        }
        private void pic_Click(object sender, MouseEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            // 取得 pic 的索引值
            int index = int.Parse(pic.Name.Replace("pic", ""));
            // 如果 pic 的 Tag 為 back，則將顯示撲克牌
            if (pic.Tag.ToString() == "back")
            {
                pic.Tag = "front";
                pic.Image = GetImage("pic" + (playerPoker[index] + 1));
            }
            else
            {
                pic.Tag = "back";
                pic.Image = GetImage("back");
            }
        }
        int[] allPoker = new int[52];
        int[] playerPoker = new int[5];
        private async void btnDealCard_Click(object sender, EventArgs e)
        {
           
        }
        private void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < allPoker.Length; i++)
            {
                int r = rand.Next(allPoker.Length);
                int temp = allPoker[r];
                allPoker[r] = allPoker[0];
                allPoker[0] = temp;
            }
        }

        private void frmPoker_Load(object sender, EventArgs e)
        {
            lblTotalMoney.Text = totalMoney.ToString();
            txtBet.Text = currentBet.ToString();
            btnDealCard.Enabled = false;
            btnChangeCard.Enabled = false;
        }

        private async void btnDealCard_Click_1(object sender, EventArgs e)
        {
            // 先將牌面蓋掉
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(100);
                pic[i].Image = GetImage("back");
            }
            // 初始化52張牌
            for (int i = 0; i < 52; i++)
            {
                allPoker[i] = i;
            }
            // 洗牌
            Shuffle();
            //await Task.Delay(500);
            // 發牌
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(200);
                pic[i].Image = GetImage("pic" + (allPoker[i] + 1));
                playerPoker[i] = allPoker[i];
            }
            // 啟用所有牌的點擊事件
            for (int i = 0; i < 5; i++)
            {
                pic[i].Enabled = true;
                pic[i].Tag = "front";
            }
            btnChangeCard.Enabled = true;
            btnDealCard.Enabled = false;
        }

        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            int cardIndex = 5;
            for (int i = 0; i < pic.Length; i++)
            {
                if (pic[i].Tag.ToString() == "back")
                {
                    playerPoker[i] = allPoker[cardIndex];
                    pic[i].Image = GetImage("pic" + (playerPoker[i] + 1));
                    pic[i].Tag = "front";
                    cardIndex++;
                }
            }
            // 禁用所有牌的點擊事件
            for (int i = 0; i < pic.Length; i++)
            {
                pic[i].Enabled = false;
            }
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = true;

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string[] colorList = { "梅花", "方塊", "愛心", "黑桃" };
            string[] pointList = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q",
"K" };
            // 計錄目前五張撲克牌的花色和點數的陣列
            int[] pokerColor = new int[5];
            int[] pokerPoint = new int[5];
            // 將每張牌的顏色和點數分別存入 pokerColor 和 pokerPoint 陣列
            for (int i = 0; i < 5; i++)
            {
                pokerColor[i] = playerPoker[i] % 4;
                pokerPoint[i] = playerPoker[i] / 4;
            }
            // 記錄花色和點數出現次數的陣列
            int[] colorCount = new int[4];
            int[] pointCount = new int[13];
            // 統計 color 和 point 出現次數
            for (int i = 0; i < 5; i++)
            {
                int color = pokerColor[i];
                int point = pokerPoint[i];
                colorCount[color]++;
                pointCount[point]++;
            }
            // 排序 colorCount 和 pointCount 由大到小
            Array.Sort(colorCount, colorList);
            Array.Reverse(colorCount);
            Array.Reverse(colorList);
            Array.Sort(pointCount, pointList);
            Array.Reverse(pointCount);
            Array.Reverse(pointList);
            // 判斷是否為同花
            bool isFlush = (colorCount[0] == 5);
            // 判斷是否為五張單張
            bool isSingle = (pointCount[0] == 1 && pointCount[1] == 1 && pointCount[2] == 1 &&
            pointCount[3] == 1 && pointCount[4] == 1);
            // 判斷是否為差四
            bool isDiffFout = (pokerPoint.Max() - pokerPoint.Min() == 4);
            // 判斷是否為大順
            bool isRoyal = pokerPoint.Contains(0) && pokerPoint.Contains(9) &&
            pokerPoint.Contains(10) && pokerPoint.Contains(11) && pokerPoint.Contains(12);
            // 判斷是否為同花大順
            bool isRoyalisFlush = isFlush && isRoyal;
            // 判斷是否為同花順
            bool isStraightFlush = isFlush && isSingle && isDiffFout;
            // 判斷是否為順子
            bool isStraight = isSingle && (isDiffFout || isRoyal);
            // 判斷是否為鐵支
            bool isFourOfAKind = (pointCount[0] == 4);
            // 判斷是否為葫蘆
            bool isFullHouse = (pointCount[0] == 3 && pointCount[1] == 2);
            // 判斷是否為三條
            bool isThreeOfAKind = (pointCount[0] == 3 && pointCount[1] == 1);
            // 判斷是否為兩對
            bool isTwoPair = (pointCount[0] == 2 && pointCount[1] == 2);
            // 判斷是否為一對
            bool isOnePair = (pointCount[0] == 2 && pointCount[1] == 1);
            string result = "";
            int multiplier = 0; // 新增賠率變數

            // 依照講義規定的賠率表設定 multiplier
            if (isRoyalisFlush) { result = $"{colorList[0]} 同花大順"; multiplier = 250; }
            else if (isStraightFlush) { result = $"{colorList[0]} 同花順"; multiplier = 50; }
            else if (isFourOfAKind) { result = $"{pointList[0]} 鐵支"; multiplier = 25; }
            else if (isFullHouse) { result = $"{pointList[0]}三張{pointList[1]}兩張 葫蘆"; multiplier = 9; }
            else if (isFlush) { result = $"{colorList[0]} 同花"; multiplier = 6; }
            else if (isStraight) { result = "順子"; multiplier = 4; }
            else if (isThreeOfAKind) { result = $"{pointList[0]} 三條"; multiplier = 3; }
            else if (isTwoPair) { result = $"{pointList[0]},{pointList[1]} 兩對"; multiplier = 2; }
            else if (isOnePair) { result = $"{pointList[0]} 一對"; multiplier = 1; }
            else { result = "雜牌"; multiplier = 0; }

            // === 結算金錢邏輯 ===
            int winAmount = currentBet * multiplier; // 計算贏得的獎金
            totalMoney += winAmount;                 // 把贏的錢加回總資金

            // 讓結果顯示更生動
            if (winAmount > 0)
            {
                lblResult.Text = $"{result}！贏得 {winAmount} 元！";
            }
            else
            {
                lblResult.Text = $"{result}！輸了 {currentBet} 元！";
            }

            // 更新畫面上的總資金數字
            lblTotalMoney.Text = totalMoney.ToString();

            // === 遊戲重置，準備下一局 ===
            btnChangeCard.Enabled = false;
            btnCheck.Enabled = false;
            btnDealCard.Enabled = false; // 關閉發牌 (必須重新下注)

            btnBet.Enabled = true;       // 重新開放下注按鈕
            txtBet.Enabled = true;       // 重新開放輸入框
        }
        private void ShowCards()
        {
            for (int i = 0; i < 5; i++)
            {
                pic[i].Image = this.GetImage($"pic{playerPoker[i] + 1}");
            }
        }

        private void frmPoker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (btnDealCard.Enabled == false && btnBet.Enabled == false)
            {
                switch (e.KeyChar)
                {
                    case 'q': // q鍵
                              // 同花大順
                        playerPoker[0] = 51;
                        playerPoker[1] = 47;
                        playerPoker[2] = 43;
                        playerPoker[3] = 39;
                        playerPoker[4] = 3;
                        break;
                    case 'w': // w鍵
                              // 同花順
                        playerPoker[0] = 37;
                        playerPoker[1] = 33;
                        playerPoker[2] = 29;
                        playerPoker[3] = 25;
                        playerPoker[4] = 21;
                        break;
                    case 'e': // e鍵
                              // 同花
                        playerPoker[0] = 50;
                        playerPoker[1] = 38;
                        playerPoker[2] = 34;
                        playerPoker[3] = 22;
                        playerPoker[4] = 18;
                        break;
                    case 'r': // r鍵
                              // 鐵支
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 38;
                        playerPoker[3] = 37;
                        playerPoker[4] = 36;
                        break;
                    case 't': // t鍵
                              // 葫蘆
                        playerPoker[0] = 30;
                        playerPoker[1] = 29;
                        playerPoker[2] = 6;
                        playerPoker[3] = 5;
                        playerPoker[4] = 4;
                        break;
                    case 'y': // y鍵
                              // 三條
                        playerPoker[0] = 48;
                        playerPoker[1] = 39;
                        playerPoker[2] = 15;
                        playerPoker[3] = 14;
                        playerPoker[4] = 13;
                        break;

                    default:
                        return;
                }
                // 顯示五張撲克牌到桌面上
                ShowCards();
            }
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            // 1. 防呆：確認輸入的是正確的整數，且金額大於 0
            if (!int.TryParse(txtBet.Text, out currentBet) || currentBet <= 0)
            {
                MessageBox.Show("請輸入正確的下注金額！");
                return;
            }

            // 2. 防呆：確認資金足夠
            if (currentBet > totalMoney)
            {
                MessageBox.Show("資金不足！");
                return;
            }

            // 3. 扣除下注金額，並更新畫面
            totalMoney -= currentBet;
            lblTotalMoney.Text = totalMoney.ToString();

            // 4. 控制按鈕與輸入框狀態 (鎖定下注，開放發牌)
            btnBet.Enabled = false;       // 鎖定下注按鈕
            txtBet.Enabled = false;       // 鎖定輸入框
            btnDealCard.Enabled = true;   // 開放「發牌」按鈕讓遊戲開始
        }
    }
}
