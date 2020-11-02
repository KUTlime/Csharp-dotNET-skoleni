Get-ChildItem -Path $PSScriptRoot -Recurse -File -Filter 'Solution.cs' | ForEach-Object {
    '' | Set-Content -Path $_.FullName -Encoding:unicode
}