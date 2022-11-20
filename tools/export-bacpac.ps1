param(
    [Parameter(Mandatory)]
    [ValidateScript({ Test-Path $_ })]
    $sourceFile,
    $server = 'mssql',
    $database = 'default'
) 

$p = Resolve-Path $sourceFile | Select-Object -ExpandProperty Path
Write-Host "Installing $p into server '$server', database '$database'..."

$token = az account get-access-token --resource='https://database.windows.net/' --query accessToken --output tsv -t 48ff16b3-6a4e-440a-afe3-d287d589e78b

& "$PSScriptRoot\sqlpackage\SqlPackage.exe" /Action:Import /SourceFile:$p `
    /TargetConnectionString:"Server=tcp:$($server).database.windows.net,1433;Initial Catalog=$($database);MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" `
    /at:$token
