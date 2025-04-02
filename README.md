# 💬 BacklogChamados – Controle de Chamados com C# Windows Forms

O **BacklogChamados** é uma aplicação de controle de chamados desenvolvida em **C# utilizando Windows Forms** com o padrão de arquitetura **MVC**. Projetado para profissionais de suporte técnico ou equipes de atendimento, o sistema permite gerenciar atendimentos em backlog de forma simples, organizada e eficiente.

---

## ⚙️ Funcionalidades

- ✅ Login com controle de acesso por ID e senha
- ✅ Cadastro de chamados com número, telefone e status inicial
- ✅ Status personalizáveis:
  - 1º Contato
  - 2º Contato
  - 3º Contato
  - Em Andamento
  - Resolvido
  - Cancelado
- ✅ Listagem de chamados com destaque por cor de status
- ✅ Alteração de status diretamente no DataGridView
- ✅ Log completo de movimentações de status
- ✅ Geração de relatório diário em `.txt` com seleção do local de salvamento
- ✅ Versão portátil: basta extrair e executar o `.exe` (não requer instalação)

---

## 🗃️ Banco de Dados

- Utiliza **MariaDB**
- Tabelas:
  - `usuarios`
  - `chamados`
  - `movimentacoes`

📎 O script SQL para criação das tabelas está incluído no repositório (`db_chamados.sql`).

---

## 🚀 Como usar

1. Clone o repositório ou baixe o `.zip`
2. Configure o banco MariaDB com o script
3. Ajuste a string de conexão no arquivo `DataBaseMariaDB.cs`
4. Compile o projeto ou execute o `.exe` da versão portátil
5. Faça login com um usuário criado manualmente (ex: ID: `1`, Senha: `1`)

---

## 🧰 Tecnologias Utilizadas

- C# (.NET Framework)
- Windows Forms (WinForms)
- MySQL/MariaDB
- Padrão MVC
- SaveFileDialog para exportação de relatórios
- DataGridView para interação com dados

---

## 📝 Sobre o Projeto

Esse projeto foi criado com foco no aprendizado e na prática de boas práticas em C#, Windows Forms e controle de banco de dados com MariaDB, simulando um sistema de chamados com controle de backlog.

---

## 👤 Autor(a)

Desenvolvido por Jamilly   
📧 jamillychaves.dev@gmail.com  

