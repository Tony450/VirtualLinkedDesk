@echo off

openssl pkcs12 -export -in Client.cer -inkey Client.key -out Client.pfx

EXIT /B

