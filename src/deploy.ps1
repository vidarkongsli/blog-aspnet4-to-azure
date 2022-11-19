param (
    $rg = 'blog-netlegacy-rg',
    $subscription = '0e39107c-468f-41a4-a1ce-231f97cf4944'
)

$projectPath = "$psscriptroot\Kongsli.LegacyNetFramework.Web\"

Remove-Item "$projectPath\WebappContent\*" -Recurse

msbuild.exe $projectPath `
    /p:platform=AnyCPU /p:DeployOnBuild=true /p:WebPublishMethod=FileSystem /p:PackageAsSingleFile=true `
    /p:DeleteExistingFiles=true /p:Configuration="Release" /p:DeployDefaultTarget=WebPublish `
    /p:publishUrl=".\\WebAppContent"

Compress-Archive -Path "$projectPath\WebappContent\*" -DestinationPath "$psscriptroot\bundle.zip" -Force

$webAppName = "$($rg.Replace('-rg',''))-app"

az webapp deploy --resource-group $rg --name $webAppName --src-path $psscriptroot\bundle.zip `
    --type zip --async true --subscription $subscription
