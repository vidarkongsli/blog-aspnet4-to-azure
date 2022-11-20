<#

Initiate local SQL server container for the first time. Will delete existing container

#>

param(
    [switch]$interactive,
    [Parameter(Mandatory = $false)]
    $saPassword = 'Ypzmkuxb5uxh7fkb6lkrtk307euwf3ofgfno727fd0'
)
$containerName = 'legacynet4_mssql'

docker container inspect $containerName 2>&1 | Out-Null
if ($?) {
    Write-Host 'Removing existing container.'
    docker container rm $containerName    
}

$extraParams = if ($interactive) { @('-it') } else { @() }
docker run `
    @extraParams `
    --name $containerName `
    -e 'ACCEPT_EULA=Y' `
    -e "SA_PASSWORD=$saPassword" `
    -p 1433:1433 `
    -v "$(Get-Location):/tmp/data" `
    -d mcr.microsoft.com/mssql/server:2019-latest 
