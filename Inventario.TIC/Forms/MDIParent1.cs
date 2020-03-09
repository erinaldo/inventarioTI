﻿using Inventario.TIC.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario.TIC
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void computadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void computadoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            int w = Screen.PrimaryScreen.Bounds.Width;
            // int h = Screen.PrimaryScreen.Bounds.Height;
            FrmComputadores newMDIChild = new FrmComputadores();
            newMDIChild.MdiParent = this;

            if(w == 1366)
                newMDIChild.WindowState = FormWindowState.Maximized;
            else
                newMDIChild.WindowState = FormWindowState.Normal;

            newMDIChild.Show();
        }

        private void notaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotaFiscal newMDIChild = new FrmNotaFiscal();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void softwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSoftware newMDIChild = new FrmSoftware();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void licençasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void licençasNFXSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLicencas newMDIChild = new FrmLicencas();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }

        private void associarLicençaNoComputadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAssociarLicencaNoComputador newMDIChild = new FrmAssociarLicencaNoComputador();
            newMDIChild.MdiParent = this;

            int w = Screen.PrimaryScreen.Bounds.Width;
            if (w == 1366)
                newMDIChild.WindowState = FormWindowState.Maximized;
            else
                newMDIChild.WindowState = FormWindowState.Normal;

            newMDIChild.Show();
        }

        private void gerenciamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = "";
            Screen.AllScreens.ToList().ForEach(a =>
            {
                text += a.DeviceName;
            });

            MessageBox.Show(text.ToString());
        }
    }
}
