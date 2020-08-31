<template>
  <section>
    <!-- <b-button type="is-primary mr-3" @click="getclientes" icon-left="refresh">Atualizar</b-button> -->
    <b-button type="is-primary" tag="router-link" to="/novocliente" icon-left="account-plus">Novo cliente</b-button>
    <b-table :data="clientes">
      <template slot-scope="props">
        <b-table-column
          field="id"
          label="Cliente"
          sortable
          numeric>
          {{props.row.id}}
        </b-table-column>
        <b-table-column
          field="nome"
          label="Nome"
          sortable>
          {{props.row.nome}}
        </b-table-column>
        <b-table-column
          field="sobrenome"
          label="Sobrenome"
          sortable>
          {{props.row.sobrenome}}
        </b-table-column>
        <!-- <b-table-column
          field="nascimento"
          label="Nascimento"
          sortable>
          {{dataFormatada(props.row.nascimento)}}
        </b-table-column> -->
         <b-table-column
          field="telefone"
          label="Telefone"
          sortable>
          {{props.row.telefone}}
        </b-table-column>
        <b-table-column
          field="endereco"
          label="Endereço"
          sortable>
          {{props.row.endereco}}
        </b-table-column>
        <b-table-column
          field="acoes"
          label="Ações">
          <b-button type="is-primary mr-1" icon-left="account" tag="router-link" :to="'/cliente/' + props.row.id">Cliente</b-button>
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
      clientes: [],
      columns: [
        { field: 'id', label: 'ID', numeric: true },
        { field: 'nome', label: 'Nome' },
        { field: 'sobrenome', label: 'Sobrenome' },
        { field: 'endereco', label: 'Endereço' }
      ]
    }
  },
  methods: {
    getCliente () {
      axios.get('http://localhost:5000/api/cliente').then(ret => {
        this.clientes = ret.data
      })
    },
    deleteCliente (id) {
      axios.delete('http://localhost:5000/api/cliente/' + id).then(() => {
        this.$buefy.toast.open({
          message: 'Cliente deletado com sucesso.',
          type: 'is-success'
        })
        this.getCliente()
      }).catch(() => {
        this.$buefy.toast.open({
          message: 'erro ao deletar cliente.',
          type: 'is-danger'
        })
      })
    }
    //,
    // dataFormatada (date) {
    //   const data = new Date(date)
    //   const dia = data.getDate().toString()
    //   const diaF = (dia.length === 1) ? '0' + dia : dia
    //   const mes = (data.getMonth() + 1).toString() // +1 pois no getMonth Janeiro começa com zero.
    //   const mesF = (mes.length === 1) ? '0' + mes : mes
    //   const anoF = data.getFullYear()
    //   return diaF + '/' + mesF + '/' + anoF
    // }
  },
  mounted () {
    this.getCliente()
  }
}
</script>
