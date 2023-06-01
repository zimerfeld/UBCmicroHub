# Introdução
O objetivo da solução UBCmicroHub é apresentar um template dos tipos de projetos e recursos que serão criados.  
Este template servirá para permitir a recriação do Sistema Portal do cliente UBC.  
Seus subsistemas serão Microserviços que independem uns dos outros no sentido que se um deles necessitar de manutenção ou atualização os demais continuarão a funcionar.

# Arquitetura de Microsserviços
A seguir está a estrutura de pastas para um template de arquitetura de microsserviços .NET Core com intercomunicação entre os microserviços:

```
UBCmicroHub
├── src
│   ├── Service1
│   │   ├── Service1.Api (projeto de console)
│   │   │   ├── Controllers
│   │   │   ├── Models
│   │   │   └── Services
│   │   ├── Service1.Domain (projeto de classe)
│   │   │   ├── Entities
│   │   │   ├── Repositories
│   │   │   └── Services
│   │   ├── Service1.Infrastructure (projeto de classe)
│   │   │   ├── Data
│   │   │   ├── Migrations
│   │   │   └── Repositories
│   │   └── Service1.Messaging (projeto de classe)
│   │       ├── Consumers
│   │       ├── Producers
│   │       └── MessageModels
│   ├── Service2
│   │   ├── Service2.Api (projeto de console)
│   │   │   ├── Controllers
│   │   │   ├── Models
│   │   │   └── Services
│   │   ├── Service2.Domain (projeto de classe)
│   │   │   ├── Entities
│   │   │   ├── Repositories
│   │   │   └── Services
│   │   ├── Service2.Infrastructure (projeto de classe)
│   │   │   ├── Data
│   │   │   ├── Migrations
│   │   │   └── Repositories
│   │   └── Service2.Messaging (projeto de classe)
│   │       ├── Consumers
│   │       ├── Producers
│   │       └── MessageModels
│   └── Shared 
│       ├── Shared.Domain (projeto de classe)
│       │   ├── Entities
│       │   ├── Repositories
│       │   └── Services
│       ├── Shared.Common (projeto de classe)
│       ├── Shared.Extensions (projeto de classe)
│       └── Shared.Models (projeto de classe)
├── tests
│   ├── Service1.Tests (projeto de teste)
│   ├── Service2.Tests (projeto de teste)
│   └── Shared.Tests (projeto de teste)
├── docs
├── .gitignore
├── UBCmicroHub.sln
└── README.md
```

# Descrição do template
A estrutura de pastas apresenta diretórios separados para cada microsserviço (Service1, Service2) e um diretório Shared para código comum.

Além dos diretórios Api, Domain e Infrastructure, agora há um diretório Messaging em cada microsserviço.

O diretório Messaging contém subdiretórios para Consumers, Producers e MessageModels.  
Os consumidores contêm classes consumidoras de mensagens responsáveis ​​por receber e processar mensagens de outros microsserviços.  
Os produtores contêm classes produtoras de mensagens responsáveis ​​por enviar mensagens para outros microsserviços.  
MessageModels contém os modelos usados ​​para serialização e desserialização de mensagens.  
Ao incluir os componentes de mensagens, os microsserviços podem se comunicar usando um sistema de mensagens (por exemplo, RabbitMQ, Azure Service Bus, Kafka).  
Cada microsserviço pode consumir mensagens de outros microsserviços e produzir mensagens que podem ser consumidas por outros microsserviços, possibilitando a comunicação e coordenação entre eles.  

Lembre-se de que a estrutura exata pode variar dependendo de suas necessidades e preferências específicas. Este exemplo fornece uma base para organizar seus microsserviços com recursos de intercomunicação.

A distinção entre Service1.Domain.Repositories e Service1.Infrastructure.Repositories é baseada na separação de preocupações e responsabilidades dentro da arquitetura de microsserviços.

Service1.Domain.Repositories:  
Este diretório pertence ao microsserviço Service1.  
Ele contém repositórios relacionados à camada de domínio do microsserviço.  
Os repositórios neste diretório normalmente definem interfaces ou classes responsáveis ​​por consultar e manipular entidades de domínio específicas para Service1.  
Os repositórios de domínio encapsulam a lógica de negócios e as operações relacionadas ao acesso a dados no microsserviço Service1.  
Por exemplo, você pode ter interfaces como IUserRepository, IOrderRepository, etc., definindo o contrato para acessar e gerenciar usuários e pedidos dentro do Service1.  

Serviço1.Infraestrutura.Repositórios:  
Este diretório também pertence ao microsserviço Service1.  
Ele contém repositórios relacionados à infraestrutura ou camada de acesso a dados do microsserviço.  
Os repositórios neste diretório são responsáveis ​​pela implementação das interfaces definidas no diretório Service1.Domain.Repositories.  
Os repositórios de infraestrutura lidam com os mecanismos reais de acesso e persistência de dados, como consultas de banco de dados, operações ORM ou integrações de serviços externos específicos para Service1.  

Por exemplo, você pode ter classes como SqlServerUserRepository, MongoDbOrderRepository, etc., implementando as interfaces IUserRepository, IOrderRepository definidas em Service1.Domain.Repositories.  
A separação de repositórios de domínio (Service1.Domain.Repositories) e repositórios de infraestrutura (Service1.Infrastructure.Repositories) ajuda a reforçar o princípio da separação de preocupações e manter uma arquitetura clara e modular. Ele permite flexibilidade e desacoplamento entre a lógica do domínio e os detalhes de implementação específicos relacionados ao acesso e persistência de dados.  

No diretório Shared, há um diretório Domain que contém os modelos, repositórios e serviços de domínio compartilhado.  
O diretório Entities contém as classes de entidade de domínio que são compartilhadas entre os microsserviços.  
O diretório Repositories contém as interfaces ou classes responsáveis ​​pelo acesso e persistência dos dados relacionados às entidades compartilhadas.  
O diretório de serviços contém as interfaces ou classes responsáveis ​​pela lógica de negócios e operações relacionadas às entidades compartilhadas.  
Os microsserviços (Service1 e Service2) podem referenciar os modelos de domínio compartilhado, repositórios e serviços do diretório Shared para habilitar o compartilhamento da lógica do domínio.  
Cada microsserviço pode usar os modelos, repositórios e serviços de domínio compartilhado dentro de sua própria implementação específica para evitar a duplicação e garantir a consistência.  
Essa estrutura permite manter uma lógica de domínio centralizada e compartilhada, garantindo que os microsserviços possam funcionar com estruturas de dados e operações de negócios consistentes.  
