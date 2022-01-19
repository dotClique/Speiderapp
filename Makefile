help:
	@echo 'help		- Print this information'
	@echo 'restore		- Restore the project for development'
	@echo 'format		- Run dotnet format with whitespace, style and analyzers set'
restore:
	python3 -m venv venv
	. ./venv/bin/activate
	python3 -m pip install -r requirements.pip
	dotnet tool restore
	dotnet restore
	pre-commit install
format:
	dotnet format --severity info
