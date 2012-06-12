

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/Tracker.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

TRACKER_EXE_MDB_SOURCE=bin/Debug/Tracker.exe.mdb
TRACKER_EXE_MDB=$(BUILD_DIR)/Tracker.exe.mdb
NOTIFY_SHARP_DLL_SOURCE=../../../../../usr/lib/mono/notify-sharp/notify-sharp.dll

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/Tracker.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

TRACKER_EXE_MDB=
NOTIFY_SHARP_DLL_SOURCE=../../../../../usr/lib/mono/notify-sharp/notify-sharp.dll

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(TRACKER_EXE_MDB) \
	$(NOTIFY_SHARP_DLL)  

BINARIES = \
	$(TASK_TRACKER)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	Main.cs \
	AssemblyInfo.cs \
	gtk-gui/generated.cs \
	AddTask.cs \
	gtk-gui/task_tracker.AddTask.cs \
	Tasks.cs \
	TaskSettings.cs \
	Dialog_Settings.cs \
	gtk-gui/task_tracker.Dialog_Settings.cs \
	RequestWork.cs \
	Reports.cs \
	Select_Date.cs \
	gtk-gui/task_tracker.Select_Date.cs \
	WorkReport.cs \
	gtk-gui/task_tracker.WorkReport.cs \
	TaskWindow.cs \
	gtk-gui/task_tracker.TaskWindow.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic 

EXTRAS = \
	appointment-new-4.ico \
	COPYING \
	setup \
	TODO.txt \
	notify-sharp.dll \
	task_tracker.desktop \
	task_tracker.in 

REFERENCES =  \
	System \
	$(GTK_SHARP_20_LIBS) \
	Mono.Posix \
	System.Xml

DLL_REFERENCES =  \
	../../../../../usr/lib/mono/notify-sharp/notify-sharp.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

NOTIFY_SHARP_DLL = $(BUILD_DIR)/notify-sharp.dll
TASK_TRACKER = $(BUILD_DIR)/task_tracker

$(eval $(call emit-deploy-target,NOTIFY_SHARP_DLL))
$(eval $(call emit-deploy-wrapper,TASK_TRACKER,task_tracker,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
