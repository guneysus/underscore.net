default: all

PROJECTS := underscore.net concurrent.net exp.net fn.net fs.net std.net iter.net math.net refl.net rgx.net www.net

all: $(PROJECTS)
		
$(PROJECTS):
	dotnet build -c Release src\$@\$@.csproj
	
	dotnet pack \
		-o dist/ \
		-c Release \
		-p:PackageId=$@ \
		-p:PackageVersion="0.1.0+92.Branch.master.Sha.f271d1441159ead823b44623deba68d2225e3480" \
		-p:PackageVersionPrefix="" \
		-p:PackageVersionSuffix="" \
		-p:Authors="Ahmed Seref GUNEYSU" \
		-p:Title="underscore.net" \
		-p:PackageRequireLicenseAcceptance=true \
		-p:Copyright="Copyright (c) 2020 Ahmed Seref GUNEYSU" \
		-p:Description="Handy tools for .NET Core developer for daily usage." \
		-p:PackageProjectUrl="https://guneysus.github.io/docs/underscore-net/" \
		-p:PackageTags="dotnet helpers" \
		-p:PackageReleaseNotes="" \
		-p:RepositoryUrl="https://github.com/guneysus/underscore.net" \
		-p:RepositoryCommit="195f1ed47b9c9fb45a0d45ecc5bdcb8d2990a085" \
		src\$@\$@.csproj
	
push:
	nuget push dist\*.nupkg $(MYGET_SECRET) -Source $(MYGET_SOURCE)
	
test:
	dotnet test .\src\UnderscoreHelpers.sln
	
.PHONY: default all push test $(PROJECTS)