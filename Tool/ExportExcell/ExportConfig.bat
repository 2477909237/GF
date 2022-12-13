set dotnet=dotnet
set Luban.ClientServer.dll=..\LuBanTools\Luban.ClientServer\Luban.ClientServer.dll
set define_date_dir=..\..\Common\Defines\__root__.xml
set input_data_dir=..\..\Common\GameDatas
set output_data_dir=..\..\Common\Export\Json
set output_dataBytes_dir=..\..\Common\Export\Bytes
set output_code_dir=..\..\GFProject\Assets\Scripts\DataTable
set output_dataBytes_prodir=..\..\GFProject\Assets\Resources\LocalConfig
set gen_types=code_cs_unity_bin,data_json


%dotnet% %Luban.ClientServer.dll% -j cfg --^
 -d %define_date_dir% ^
 --input_data_dir %input_data_dir% ^
 --output_data_dir %output_data_dir% ^
 --output_code_dir %output_code_dir% ^
 --gen_types %gen_types% ^
 -s all
 
 %dotnet% %Luban.ClientServer.dll% -j cfg --^
 -d %define_date_dir% ^
 --input_data_dir %input_data_dir% ^
 --output_data_dir %output_dataBytes_dir% ^
 --gen_types data_bin ^
 -s all
 
  %dotnet% %Luban.ClientServer.dll% -j cfg --^
 -d %define_date_dir% ^
 --input_data_dir %input_data_dir% ^
 --output_data_dir %output_dataBytes_prodir% ^
 --gen_types data_bin ^
 -s all
pause