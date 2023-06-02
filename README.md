# Introdução
O objetivo da solução MicroServiceTemplate é apresentar um modelo base para start-up da recriação do Sistema Portal do cliente UBC.  
Os subsistemas que o compôe serão formados por outros Microserviços que independem deste para pleno funcionamento.  
Caso um subsistema necessite de manutenção ou atualização os demais continuarão a funcionar.  

# Arquitetura de Microserviços
A seguir apresenta-se a estrutura de pastas e respectivos tipos de projetos que serão utilizados na composição da arquitetura de microserviços .NET Core com intercomunicação entre eles:

```
MicroServiceTemplate
├── MicroServiceTemplate.Api (projeto de console)
│   ├── Controllers
│   ├── Models
│   └── Services
├── MicroServiceTemplate.Domain (projeto de classe)
│   ├── Entities
│   ├── Repositories
│   └── Services
├── MicroServiceTemplate.Infrastructure (projeto de classe)
│   ├── Data
│   ├── Migrations
│   └── Repositories
├── MicroServiceTemplate.Messaging (projeto de classe)
│   ├── Consumers
│   ├── Producers
│   └── MessageModels
├── MicroServiceTemplate.Tests (projeto de teste)
│   ├── Api
│   ├── Domain
│   ├── Infrastructure
│   └── Messaging
├── docs
├── .gitignore
├── MicroServiceTemplate.sln
└── README.md
```

# Descrição do template
A estrutura de pastas apresenta a organização de projetos isolados para cada microserviço.

Além dos projetos Api, Domain e Infrastructure, haverá também um projeto Messaging em cada microserviço.

## O subprojeto Messaging
O projeto Messaging contém subdiretórios para Consumers, Producers e MessageModels.  
Os consumidores contêm classes consumidoras de mensagens responsáveis ​​por receber e processar mensagens de outros microserviços.  
Os produtores contêm classes produtoras de mensagens responsáveis ​​por enviar mensagens para outros microserviços.  
MessageModels contém os modelos usados ​​para serialização e desserialização de mensagens.  
Ao incluir os componentes de mensagens, os microserviços podem se comunicar usando um sistema de mensagens (por exemplo, RabbitMQ, Azure Service Bus, Kafka).  
Cada microserviço pode consumir mensagens de outros microserviços e produzir mensagens que podem ser consumidas por outros microserviços, possibilitando a comunicação e coordenação entre eles.  

Lembrando de que a estrutura pode variar dependendo de suas necessidades e preferências específicas.  
Este exemplo fornece uma base para organizar seus microserviços com recursos de intercomunicação.

## A distinção entre MicroServiceTemplate.Domain.Repositories e MicroServiceTemplate.Infrastructure.Repositories 
A distinção é baseada na separação de preocupações e responsabilidades dentro da arquitetura de microserviços.

### MicroServiceTemplate.Domain.Repositories:  
Este diretório pertence ao microserviço MicroServiceTemplate.  
Ele contém repositórios relacionados à camada de domínio do microserviço.  
Os repositórios neste diretório normalmente definem **interfaces ou classes** responsáveis ​​por consultar e manipular entidades de domínio específicas para Service1.  
Os repositórios de domínio encapsulam a **lógica de negócios e as operações relacionadas ao acesso a dados** no microserviço MicroServiceTemplate.  

Por exemplo, você pode ter interfaces como IUserRepository, IOrderRepository, etc., definindo o contrato para acessar e gerenciar usuários e pedidos dentro do Service1.  

### MicroServiceTemplate.Infraestrutura.Repositórios:  
Este diretório também pertence ao microserviço MicroServiceTemplate.  
Ele contém repositórios relacionados à infraestrutura ou camada de acesso a dados do microserviço.  
Os repositórios neste diretório são responsáveis ​​pela **implementação das interfaces definidas** no diretório MicroServiceTemplate.Domain.Repositories.  
Os repositórios de infraestrutura lidam com os **mecanismos reais de acesso e persistência de dados**, como consultas de banco de dados, operações ORM ou **integrações de serviços externos específicos** para Service1.  

Por exemplo, você **pode ter classes** como SqlServerUserRepository, MongoDbOrderRepository, etc., **implementando as interfaces** IUserRepository, IOrderRepository definidas em Service1.Domain.Repositories.  
A separação de repositórios de domínio (MicroServiceTemplate.Domain.Repositories) e repositórios de infraestrutura (MicroServiceTemplate.Infrastructure.Repositories) ajuda a reforçar o princípio da separação de preocupações e manter uma arquitetura clara e modular.  
Ele permite **flexibilidade e desacoplamento** entre a lógica do domínio e os detalhes de implementação específicos relacionados ao acesso e persistência de dados.  

Cada microserviço pode usar os modelos, repositórios e serviços de domínio compartilhado dentro de sua própria implementação específica para evitar a duplicação e garantir a consistência.  
Essa estrutura permite manter uma lógica de domínio descentralizada e compartilhada, garantindo que os microserviços possam funcionar com estruturas de dados e operações de negócios consistentes.  
