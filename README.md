# Inventify - Backend

## Visão Geral

O **Inventify** é um Sistema de Controle de Inventário Inteligente que utiliza machine learning para prever demandas, gerenciar estoques com eficiência e fornecer análises em tempo real. O backend da aplicação foi desenvolvido utilizando **C#** e **.NET**, garantindo segurança, escalabilidade e alta performance.

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET
- **Banco de Dados:** SQL Server, MongoDB
- **Machine Learning:** TensorFlow/PyTorch
- **Infraestrutura:** Docker, Kubernetes
- **CI/CD:** GitHub Actions
- **Monitoramento:** Prometheus, Grafana

## Funcionalidades Principais

1. **Gestão de Inventário**
   - Controle de estoque em tempo real com atualização automática.
2. **Previsão de Demanda**
   - Algoritmos de Machine Learning para prever a demanda futura de produtos.
3. **Integração com ERP/CRM**
   - Sincronização de dados com sistemas empresariais.
4. **Alertas de Estoque Baixo**
   - Notificações automáticas quando o estoque estiver abaixo do limite.
5. **Histórico de Movimentações**
   - Registra todas as entradas e saídas de produtos.
6. **APIs Seguras e Escaláveis**
   - Endpoints RESTful protegidos com autenticação JWT.
7. **Automatização de Pedidos**
   - Geração automática de pedidos com base em previsão de demanda.

## Configuração do Ambiente

### Pré-requisitos

- **.NET SDK** (versão compatível)
- **Docker** (para execução em containers)
- **Banco de Dados:** SQL Server, MongoDB

### Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/inventify-backend.git
   cd inventify-backend
   ```
2. Instale as dependências:
   ```bash
   dotnet restore
   ```
3. Configure as variáveis de ambiente:
   - Crie um arquivo `.env` com as configurações necessárias (exemplo no `.env.example`).

4. Execute o projeto em modo de desenvolvimento:
   ```bash
   dotnet run
   ```

### Build para Produção

```bash
 dotnet publish -c Release -o out
```

## Testes

Para rodar os testes unitários:
```bash
dotnet test
```

## Deployment

Para rodar o projeto com Docker:
```bash
docker build -t inventify-backend .
docker run -p 5000:5000 inventify-backend
```

## Contribuição

1. Faça um **fork** do repositório.
2. Crie uma **branch** para a sua feature (`git checkout -b feature-nova`)
3. Commit suas mudanças (`git commit -m 'Adicionando nova funcionalidade'`)
4. Envie para o repositório (`git push origin feature-nova`)
5. Abra um **Pull Request**

## Contato

Se precisar de suporte ou tiver alguma dúvida, entre em contato.

---

**Inventify - Sistema de Controle de Inventário Inteligente** 🚀

