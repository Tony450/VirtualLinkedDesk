@echo off

openssl genrsa -des3 -out Server.key 2048
openssl req -key Server.key -new -out Server.csr

cd ../CA
openssl x509 -req -in ../Server/Server.csr -CA CA.cer -CAkey CA.key -CAcreateserial -out ../Server/Server.cer

cd ../Server
openssl pkcs12 -export -in Server.cer -inkey Server.key -out Server.pfx

EXIT /B
