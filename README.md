# Back.Dispatcher

## Sobre
Dispatcher tratase de um pr�totipo de projeto para envio de e-mails, e expansivel para mensagens ou demais m�dias.

Sendo possivel enviar mensagens baseadas em template ou j� enviar a mensagem completa.

##Configura��o
Para rodar a aplica��o corretamente � necess�rio configurar uma conta de e-email smtp no [AppSettings](Back.Dispatcher.Api/appsettings.json)

"ConfigEmail": {
    "Smtp": "",
    "PortSmtp": 25,
    "Email": "",
    "Password": ""
  },

## Composi��o 
### api/email/ContactUs
Esta rota est� preparada para envio de e-mail baseado em template, ela faz o disparo de dois e-emails, um para o cliente [ContactUSToClient](Back.Dispatcher.Api/Repository/Templates/ContactUSToClient.html) e outro para equipe de suporte [ContactUsToSupport](Back.Dispatcher.Api/Repository/Templates/ContactUsToSupport.html)
Os dados solicitados no request ser�o substitu�dos no template. 

### api/email/send
Esta rota permite o envio de e-mail completo.