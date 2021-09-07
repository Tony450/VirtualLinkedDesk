@echo off

openssl genrsa -des3 -out CA.key 2048
openssl req -new -x509 -key CA.key -out CA.cer

EXIT /B