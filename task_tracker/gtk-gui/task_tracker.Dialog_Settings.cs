
// This file has been generated by the GUI designer. Do not modify.
namespace task_tracker
{
	public partial class Dialog_Settings
	{
		private global::Gtk.VBox vbox3;
		private global::Gtk.HBox hbox2;
		private global::Gtk.Label label2;
		private global::Gtk.Entry interval;
		private global::Gtk.Label label6;
		private global::Gtk.HBox hbox7;
		private global::Gtk.Label label9;
		private global::Gtk.Entry name;
		private global::Gtk.HBox hbox1;
		private global::Gtk.Label label1;
		private global::Gtk.Entry email_address;
		private global::Gtk.HBox hbox3;
		private global::Gtk.Label label3;
		private global::Gtk.Entry email_destination;
		private global::Gtk.HBox hbox5;
		private global::Gtk.Label label5;
		private global::Gtk.Entry email_subject;
		private global::Gtk.HBox hbox4;
		private global::Gtk.Label label4;
		private global::Gtk.Entry smtp_server;
		private global::Gtk.HBox hbox8;
		private global::Gtk.Label label10;
		private global::Gtk.Entry smtp_port;
		private global::Gtk.HBox hbox6;
		private global::Gtk.Label label7;
		private global::Gtk.Entry email_password;
		private global::Gtk.Label label8;
		private global::Gtk.Button buttonCancel;
		private global::Gtk.Button buttonOk;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget task_tracker.Dialog_Settings
			this.Name = "task_tracker.Dialog_Settings";
			this.Title = global::Mono.Unix.Catalog.GetString ("Settings");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child task_tracker.Dialog_Settings.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Reminder Interval (minutes):");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.interval = new global::Gtk.Entry ();
			this.interval.CanFocus = true;
			this.interval.Name = "interval";
			this.interval.IsEditable = true;
			this.interval.InvisibleChar = '•';
			this.hbox2.Add (this.interval);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.interval]));
			w3.Position = 1;
			this.vbox3.Add (this.hbox2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label6 = new global::Gtk.Label ();
			this.label6.Name = "label6";
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("Email Report Settings");
			this.vbox3.Add (this.label6);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label6]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox7 = new global::Gtk.HBox ();
			this.hbox7.Name = "hbox7";
			this.hbox7.Spacing = 6;
			// Container child hbox7.Gtk.Box+BoxChild
			this.label9 = new global::Gtk.Label ();
			this.label9.Name = "label9";
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString ("Name:");
			this.hbox7.Add (this.label9);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.label9]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox7.Gtk.Box+BoxChild
			this.name = new global::Gtk.Entry ();
			this.name.CanFocus = true;
			this.name.Name = "name";
			this.name.IsEditable = true;
			this.name.InvisibleChar = '•';
			this.hbox7.Add (this.name);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox7 [this.name]));
			w7.Position = 1;
			this.vbox3.Add (this.hbox7);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox7]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Email Address:");
			this.hbox1.Add (this.label1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label1]));
			w9.Position = 0;
			w9.Expand = false;
			w9.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.email_address = new global::Gtk.Entry ();
			this.email_address.CanFocus = true;
			this.email_address.Name = "email_address";
			this.email_address.IsEditable = true;
			this.email_address.InvisibleChar = '•';
			this.hbox1.Add (this.email_address);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.email_address]));
			w10.Position = 1;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w11.Position = 3;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Destination Address:");
			this.hbox3.Add (this.label3);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.label3]));
			w12.Position = 0;
			w12.Expand = false;
			w12.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.email_destination = new global::Gtk.Entry ();
			this.email_destination.CanFocus = true;
			this.email_destination.Name = "email_destination";
			this.email_destination.IsEditable = true;
			this.email_destination.InvisibleChar = '•';
			this.hbox3.Add (this.email_destination);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox3 [this.email_destination]));
			w13.Position = 1;
			this.vbox3.Add (this.hbox3);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox3]));
			w14.Position = 4;
			w14.Expand = false;
			w14.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox5 = new global::Gtk.HBox ();
			this.hbox5.Name = "hbox5";
			this.hbox5.Spacing = 6;
			// Container child hbox5.Gtk.Box+BoxChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Email Subject:");
			this.hbox5.Add (this.label5);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.label5]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child hbox5.Gtk.Box+BoxChild
			this.email_subject = new global::Gtk.Entry ();
			this.email_subject.CanFocus = true;
			this.email_subject.Name = "email_subject";
			this.email_subject.IsEditable = true;
			this.email_subject.InvisibleChar = '•';
			this.hbox5.Add (this.email_subject);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox5 [this.email_subject]));
			w16.Position = 1;
			this.vbox3.Add (this.hbox5);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox5]));
			w17.Position = 5;
			w17.Expand = false;
			w17.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("SMTP Server:");
			this.hbox4.Add (this.label4);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.label4]));
			w18.Position = 0;
			w18.Expand = false;
			w18.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.smtp_server = new global::Gtk.Entry ();
			this.smtp_server.CanFocus = true;
			this.smtp_server.Name = "smtp_server";
			this.smtp_server.IsEditable = true;
			this.smtp_server.InvisibleChar = '•';
			this.hbox4.Add (this.smtp_server);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.hbox4 [this.smtp_server]));
			w19.Position = 1;
			this.vbox3.Add (this.hbox4);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox4]));
			w20.Position = 6;
			w20.Expand = false;
			w20.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox8 = new global::Gtk.HBox ();
			this.hbox8.Name = "hbox8";
			this.hbox8.Spacing = 6;
			// Container child hbox8.Gtk.Box+BoxChild
			this.label10 = new global::Gtk.Label ();
			this.label10.Name = "label10";
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString ("SMTP Port:");
			this.hbox8.Add (this.label10);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.label10]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox8.Gtk.Box+BoxChild
			this.smtp_port = new global::Gtk.Entry ();
			this.smtp_port.CanFocus = true;
			this.smtp_port.Name = "smtp_port";
			this.smtp_port.IsEditable = true;
			this.smtp_port.InvisibleChar = '●';
			this.hbox8.Add (this.smtp_port);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox8 [this.smtp_port]));
			w22.Position = 1;
			this.vbox3.Add (this.hbox8);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox8]));
			w23.Position = 7;
			w23.Expand = false;
			w23.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label ();
			this.label7.Name = "label7";
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString ("Email Password:");
			this.hbox6.Add (this.label7);
			global::Gtk.Box.BoxChild w24 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label7]));
			w24.Position = 0;
			w24.Expand = false;
			w24.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.email_password = new global::Gtk.Entry ();
			this.email_password.CanFocus = true;
			this.email_password.Name = "email_password";
			this.email_password.IsEditable = true;
			this.email_password.Visibility = false;
			this.email_password.InvisibleChar = '•';
			this.hbox6.Add (this.email_password);
			global::Gtk.Box.BoxChild w25 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.email_password]));
			w25.Position = 1;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label8 = new global::Gtk.Label ();
			this.label8.Name = "label8";
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString ("Warning: Plain Text!");
			this.hbox6.Add (this.label8);
			global::Gtk.Box.BoxChild w26 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label8]));
			w26.Position = 2;
			w26.Expand = false;
			w26.Fill = false;
			this.vbox3.Add (this.hbox6);
			global::Gtk.Box.BoxChild w27 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox6]));
			w27.Position = 8;
			w27.Expand = false;
			w27.Fill = false;
			w1.Add (this.vbox3);
			global::Gtk.Box.BoxChild w28 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox3]));
			w28.Position = 0;
			w28.Expand = false;
			w28.Fill = false;
			// Internal child task_tracker.Dialog_Settings.ActionArea
			global::Gtk.HButtonBox w29 = this.ActionArea;
			w29.Name = "dialog1_ActionArea";
			w29.Spacing = 10;
			w29.BorderWidth = ((uint)(5));
			w29.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w30 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w29 [this.buttonCancel]));
			w30.Expand = false;
			w30.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w31 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w29 [this.buttonOk]));
			w31.Position = 1;
			w31.Expand = false;
			w31.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 432;
			this.DefaultHeight = 381;
			this.Show ();
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
