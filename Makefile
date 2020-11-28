install: publish
	[ -d $(DESTDIR)/bin ] || \
		(mkdir -p $(DESTDIR)/usr/bin)
	cp build/Kirigiri $(DESTDIR)/usr/bin/

publish:
	dotnet publish -r linux-x64 -p:PublishSingleFile=true --self-contained false -o build/ Kirigiri/Kirigiri.csproj