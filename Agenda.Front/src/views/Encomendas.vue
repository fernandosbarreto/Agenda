<template>
  <section>
    <!-- <b-button type="is-primary mr-3" @click="getclientes" icon-left="refresh">Atualizar</b-button> -->
    <b-button type="is-primary" tag="router-link" to="/novocliente" icon-left="account-plus">Novo cliente</b-button>
    <b-table :data="encomendas">
      <template slot-scope="props">
        <b-table-column
          field="id"
          label="Nº encomenda"
          sortable
          numeric>
          {{props.row.id}}
        </b-table-column>
        <b-table-column
          field="cliente"
          label="Cliente"
          sortable>
          {{props.row.cliente.nome}}
        </b-table-column>
        <b-table-column
          field="doce"
          label="Doce"
          sortable>
          {{props.row.doce.tpDoce.nomeProduto}}
        </b-table-column>
        <b-table-column
          field="sabor"
          label="Sabor"
          sortable>
          {{props.row.doce.sabor}}
        </b-table-column>
        <b-table-column
          field="quantidade"
          label="Quantidade"
          sortable>
          {{props.row.quantidade}}
        </b-table-column>
         <b-table-column
          field="preco"
          label="Preço"
          sortable>
          {{"R$ " + props.row.preco}}
        </b-table-column>
        <b-table-column
          field="entrega"
          label="Entrega"
          sortable>
          {{dataFormatada(props.row.entrega)}}
        </b-table-column>
        <b-table-column
          field="acoes"
          label="Ações">
          <b-button type="is-primary mr-1" icon-left="account" tag="router-link" :to="'/cliente/' + props.row.clienteId">Cliente</b-button>
          <b-button type="is-danger" icon-left="delete" @click="deleteCliente(props.row.id)">Excluir</b-button>
        </b-table-column>
      </template>

    </b-table>
  </section>
</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      encomendas: [],
      columns: [
        { field: 'id', label: 'Id', numeric: true },
        { field: 'doce', label: 'Doce' },
        { field: 'sabor', label: 'Sabor' },
        { field: 'quantidade', label: 'Quantidade' },
        { field: 'entrega', label: 'Entrega' }
      ]
    }
  },
  methods: {
    getEncomenda () {
      axios.get('http://localhost:5000/api/encomenda').then(ret => {
        this.encomendas = ret.data
      })
    },
    deleteEncomenda (id) {
      axios.delete('http://localhost:5000/api/encomenda/' + id).then(() => {
        this.$buefy.toast.open({
          message: 'Encomenda deletada com sucesso.',
          type: 'is-success'
        })
        this.getEncomenda()
      }).catch(() => {
        this.$buefy.toast.open({
          message: 'erro ao deletar Encomenda.',
          type: 'is-danger'
        })
      })
    },
    dataFormatada (date) {
      const data = new Date(date)
      const dia = data.getDate().toString()
      const diaF = (dia.length === 1) ? '0' + dia : dia
      const mes = (data.getMonth() + 1).toString() // +1 pois no getMonth Janeiro começa com zero.
      const mesF = (mes.length === 1) ? '0' + mes : mes
      const anoF = data.getFullYear()
      return diaF + '/' + mesF + '/' + anoF
    }
  },
  mounted () {
    this.getEncomenda()
  }
}
</script>
