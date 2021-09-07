@echo off

cd ../CA
openssl x509 -req -in ../Client/Client.csr -CA CA.cer -CAkey CA.key -CAcreateserial -out ../Client/Client.cer
cd ../Client

EXIT /B