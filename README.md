# API Rest de Locadora de Carros em ASP.NET Core
Projeto desenvolvido como parte da avaliação CP2 da disciplina ADVANCED BUSINESS DEVELOPMENT WITH .NET.

## ⚙️ Funcionalidades

### 🚗 Gerenciamento de Carros
- 🟢 Adicionar novos veículos
- 📋 Visualizar lista completa de carros cadastrados
- ✏️ Editar informações de um carro
- ❌ Remover um carro do sistema

### 📊 Cálculo de Locação
- 📎 Endpoint para simular o valor da locação com base nas datas informadas
- 💡 Aplicação automática de descontos progressivos:
  - 🔻 **10% de desconto** para locações a partir de **7 dias**
  - 🔻 **5% de desconto** para locações de **3 a 6 dias**
  - ⛔ **Sem desconto** para locações de até **2 dias**

---

## 🧩 Endpoints Disponíveis

### 🔧 Carros (CRUD)
- `GET /api/carros` — Retorna todos os carros cadastrados  
- `GET /api/carros/{id}` — Busca um carro pelo ID  
- `POST /api/carros` — Cadastra um novo carro  
- `PUT /api/carros/{id}` — Atualiza os dados de um carro existente  
- `DELETE /api/carros/{id}` — Remove um carro do sistema  

### 📐 Locação
- `POST /api/locacoes/calcular` — Realiza o cálculo do valor de locação com base no período informado

#### 📥 Exemplo de Requisição
```json
{
  "carroId": 2,
  "dataInicio": "2025-05-01",
  "dataFim": "2025-05-06"
}
```

#### 📥 Exemplo de Saída
```json
{
  "carro": "Onix",
  "marca": "Chevrolet",
  "dataInicio": "2025-05-01",
  "dataFim": "2025-05-06",
  "valorDiaria": 130.00,
  "subtotal": 780.00,
  "desconto": "5%",
  "valorFinal": 741.00
}
```
