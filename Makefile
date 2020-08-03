default: build

build: underscore

pack: build
	dotnet pack \
		-o dist/ \
		--verbosity=minimal \
		-c Release \
		-p:PackageId=underscore.net \
		-p:PackageVersion="0.1.0+87.Branch.master.Sha.195f1ed47b9c9fb45a0d45ecc5bdcb8d2990a085" \
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
		src\underscore.net\underscore.net.csproj
	
push:
	nuget push underscore.net.0.0.0.nupkg $(MYGET_SECRET) -Source $(MYGET_SOURCE)
	
test:
	dotnet test src/underscore-net-tests/
	
underscore:
	dotnet build -c Release .\src\underscore.net
	
.PHONY: default build pack pack2 push test 