
namespace POIProject
{
    partial class FormMainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQuiz = new System.Windows.Forms.Button();
            this.buttonAddQuestions = new System.Windows.Forms.Button();
            this.buttonAddPlayers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonQuiz
            // 
            this.buttonQuiz.Location = new System.Drawing.Point(507, 385);
            this.buttonQuiz.Name = "buttonQuiz";
            this.buttonQuiz.Size = new System.Drawing.Size(169, 23);
            this.buttonQuiz.TabIndex = 2;
            this.buttonQuiz.Text = "Стартиране на Куиз";
            this.buttonQuiz.UseVisualStyleBackColor = true;
            this.buttonQuiz.Click += new System.EventHandler(this.buttonQuiz_Click);
            // 
            // buttonAddQuestions
            // 
            this.buttonAddQuestions.Location = new System.Drawing.Point(43, 385);
            this.buttonAddQuestions.Name = "buttonAddQuestions";
            this.buttonAddQuestions.Size = new System.Drawing.Size(174, 23);
            this.buttonAddQuestions.TabIndex = 3;
            this.buttonAddQuestions.Text = "Добавяне на въпроси";
            this.buttonAddQuestions.UseVisualStyleBackColor = true;
            this.buttonAddQuestions.Click += new System.EventHandler(this.buttonAddQuestions_Click);
            // 
            // buttonAddPlayers
            // 
            this.buttonAddPlayers.Location = new System.Drawing.Point(270, 385);
            this.buttonAddPlayers.Name = "buttonAddPlayers";
            this.buttonAddPlayers.Size = new System.Drawing.Size(174, 23);
            this.buttonAddPlayers.TabIndex = 4;
            this.buttonAddPlayers.Text = "Добавяне на участници";
            this.buttonAddPlayers.UseVisualStyleBackColor = true;
            this.buttonAddPlayers.Click += new System.EventHandler(this.buttonAddPlayers_Click);
            // 
            // FormMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddPlayers);
            this.Controls.Add(this.buttonAddQuestions);
            this.Controls.Add(this.buttonQuiz);
            this.Name = "FormMainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Начало";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQuiz;
        private System.Windows.Forms.Button buttonAddQuestions;
        private System.Windows.Forms.Button buttonAddPlayers;
    }
}

