# Desafio Livraria - API REST em .NET

Este projeto é um desafio do curso de C# da Rocketseat.  
Trata-se de uma **API REST** para gerenciar livros de uma livraria, com CRUD completo, validações e documentação via Swagger.

---

## Estrutura do Projeto

/DesafioLivraria
├── Controllers → Contém o LivroController
├── Entities → Contém as entidades do projeto (Livro)
├── Services → Contém a lógica de negócio (LivroService)
├── Enums → Contém enums do projeto (GeneroLivro)
├── DesafioLivraria.sln
└── Program.cs

## Funcionalidades

- Criar um livro
- Listar todos os livros
- Consultar um livro específico
- Atualizar informações de um livro
- Excluir um livro
- Validações:
  - Título único
  - Autor único
	> Nota: Neste projeto não existe um cadastro separado de autores. Como se trata de um exercício de CRUD com API REST, mantive a validação diretamente no livro para evitar complexidade desnecessária.
  - Preço e estoque não negativos
  - Gênero válido
- Registro de datas:
  - `CreatedAt` quando o livro é criado
  - `UpdatedAt` quando o livro é atualizado
  
## Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| POST   | /api/livro | Criar um novo livro |
| GET    | /api/livro | Listar todos os livros |
| GET    | /api/livro/{id} | Consultar um livro por ID |
| PUT    | /api/livro | Atualizar informações de um livro |
| DELETE | /api/livro | Excluir um livro |

**Status codes usados:**

- 201 → Recurso criado (POST)
- 200 → Consulta ou atualização bem-sucedida (GET/PUT)
- 204 → Exclusão bem-sucedida (DELETE)
- 400 → Requisição malformada ou dados inválidos
- 404 → Livro não encontrado
- 409 → Conflito de dados (ex.: título duplicado)

## Observações
Todos os dados são armazenados em memória (sem banco de dados).