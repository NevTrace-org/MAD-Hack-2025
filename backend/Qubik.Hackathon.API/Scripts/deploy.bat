echo "Bienvenido al despliegue en PRODUCCION"
echo "Subiendo Lambda"
cd ..
dotnet lambda deploy-function qubichackathonbackend-AspNetCoreFunction-xbyq0NUiv34d --configuration "Release" --framework net8.0 --function-runtime dotnet6 --profile ChusPersonal --region eu-west-3
pause