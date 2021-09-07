@echo off

openssl genrsa -des3 -out Client.key 2048
openssl req -key Client.key -new -out Client.csr

EXIT /B
