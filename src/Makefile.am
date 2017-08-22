
task-tracker: task-tracker.in
	sed -e 's;[@]LIBDIR[@];$(libdir);g' -e 's;/usr/bin/python;$(PYTHON);g' -e 's;[@]BINDIR[@];$(bindir);g' -e 's;[@]SBINDIR[@];$(sbindir);g' < $(srcdir)/task-tracker.in > $(srcdir)/task-tracker
	chmod +x task-tracker

bin_SCRIPTS = task-tracker

CLEANFILES = $(bin_SCRIPTS)
EXTRA_DIST = task-tracker.in

