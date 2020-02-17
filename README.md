# aws-s3-read-write-files
## English

Example of how to Read and Write files located on AWS S3

Fill appsetting.json with your AWS Credentials:
'''
{
	"AWS": {
		"Credential": {
			"AccessKey": "your-access-key-here",
			"SecretKey": "your-secret-key-here"
		},
		"S3": {
			"Bucket": "production-portfoliomanager-files"
		}
	}
}

### There are 2 methods:
#### UploadFileAsync
For upload example

#### ReadObjectDataAsync
For read example

'''
## Português

Exemplo de como se ler e escrever arquivos localizados na amazon S3 utilizando ASP.NET core 3.1 (linguagem C#). 

Preencha o arquivo appsetting.json com seus dados de usuário na Amazon:
'''
{
	"AWS": {
		"Credential": {
			"AccessKey": "your-access-key-here",
			"SecretKey": "your-secret-key-here"
		},
		"S3": {
			"Bucket": "production-portfoliomanager-files"
		}
	}
}
'''

### Temos 2 métodos:
#### UploadFileAsync
Para exemplo de upload

#### ReadObjectDataAsync
Para exemplo de leitura

