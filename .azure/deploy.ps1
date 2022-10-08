
param (
    $rg = 'blog-netlegacy-rg',
    $subscription = '0e39107c-468f-41a4-a1ce-231f97cf4944'
)

az group create --name $rg --location NorwayEast --subscription $subscription | out-null
$name = "deploy-$(get-date -Format 'yyyy-MM-ddThh-mm-ss')"
az deployment group create --resource-group $rg --name $name `
    --template-file "$psscriptroot\azuredeploy.bicep" `
    --confirm-with-what-if `
    --subscription $subscription
