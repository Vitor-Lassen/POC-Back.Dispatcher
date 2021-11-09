# Back.Dispatcher

## Sobre
Dispatcher tratase de um prótotipo de projeto para envio de e-mails, e expansivel para mensagens ou demais mídias.

Sendo possivel enviar mensagens baseadas em template ou já enviar a mensagem completa.

##Configuração
Para rodar a aplicação corretamente é necessário configurar uma conta de e-email smtp no [AppSettings](Back.Dispatcher.Api/appsettings.json)

"ConfigEmail": {
    "Smtp": "",
    "PortSmtp": 25,
    "Email": "",
    "Password": ""
  },

## Composição 
### api/email/ContactUs
Esta rota está preparada para envio de e-mail baseado em template, ela faz o disparo de dois e-emails, um para o cliente [ContactUSToClient](Back.Dispatcher.Api/Repository/Templates/ContactUSToClient.html) e outro para equipe de suporte [ContactUsToSupport](Back.Dispatcher.Api/Repository/Templates/ContactUsToSupport.html)
Os dados solicitados no request serão substituídos no template. 

### api/email/send
Esta rota permite o envio de e-mail completo.