
// This file has been generated by the GUI designer. Do not modify.
namespace task_tracker
{
	public partial class WorkReport
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label1;
		private global::Gtk.Entry destination_email_address;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.Entry email_subject;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView email_body;
		private global::Gtk.Button selectWeek;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget task_tracker.WorkReport
			this.Name = "task_tracker.WorkReport";
			this.Title = global::Mono.Unix.Catalog.GetString ("Weekly Work Report");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child task_tracker.WorkReport.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Destination Address:");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.destination_email_address = new global::Gtk.Entry ();
			this.destination_email_address.CanFocus = true;
			this.destination_email_address.Name = "destination_email_address";
			this.destination_email_address.IsEditable = true;
			this.destination_email_address.InvisibleChar = '•';
			this.hbox1.Add (this.destination_email_address);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.destination_email_address]));
			w3.Position = 1;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Subject:");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.email_subject = new global::Gtk.Entry ();
			this.email_subject.CanFocus = true;
			this.email_subject.Name = "email_subject";
			this.email_subject.IsEditable = true;
			this.email_subject.InvisibleChar = '•';
			this.hbox2.Add (this.email_subject);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.email_subject]));
			w6.Position = 1;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.email_body = new global::Gtk.TextView ();
			this.email_body.CanFocus = true;
			this.email_body.Name = "email_body";
			this.GtkScrolledWindow.Add (this.email_body);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w9.Position = 2;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w10.Position = 0;
			// Internal child task_tracker.WorkReport.ActionArea
			global::Gtk.HButtonBox w11 = this.ActionArea;
			w11.Name = "dialog1_ActionArea";
			w11.Spacing = 10;
			w11.BorderWidth = ((uint)(5));
			w11.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.selectWeek = new global::Gtk.Button ();
			this.selectWeek.CanFocus = true;
			this.selectWeek.Name = "selectWeek";
			this.selectWeek.UseUnderline = true;
			this.selectWeek.Label = global::Mono.Unix.Catalog.GetString ("Select Week");
			this.AddActionWidget (this.selectWeek, 0);
			global::Gtk.ButtonBox.ButtonBoxChild w12 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.selectWeek]));
			w12.Expand = false;
			w12.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w13 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.buttonCancel]));
			w13.Position = 1;
			w13.Expand = false;
			w13.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w14 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w11 [this.buttonOk]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 513;
			this.DefaultHeight = 428;
			this.Show ();
			this.selectWeek.Clicked += new global::System.EventHandler (this.OnSelectWeekClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
