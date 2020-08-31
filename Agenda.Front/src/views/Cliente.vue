<template>
  <section>
    <div class="columns">
      <div class="column is-narrow">
        <div class="box">
            <p class="title is-5">Codigo do cliente: </p>
            <p class="subtitle">{{clientes.id}}</p>
        </div>
      </div>
      <div class="column"></div>
      <div class="column is-narrow">
        <div class="box">
          <b-button type="is-primary mr-1 is-warning" icon-left="account-edit" tag="router-link" :to="'/editarcliente/' + this.clienteid">Editar</b-button>
            <b-button type="is-primary" tag="router-link" :to="'/novaencomenda/'+ this.clienteid" icon-left="plus">Nova encomenda</b-button>
        </div>
      </div>
    </div>
    <template>
      <div class="columns">
        <div class="column">
          <div class="box">
            <p class="title is-5">Nome: </p>
            <p class="subtitle">{{clientes.nome}}</p>
          </div>
          <div class="box">
            <p class="title is-5">Sobrenome: </p>
            <p class="subtitle">{{clientes.sobrenome}}</p>
          </div>
        </div>
        <div class="column">
          <div class="box">
            <p class="title is-5">Telefone: </p>
            <p class="subtitle">{{clientes.telefone}}</p>
          </div>
          <div class="box">
            <p class="title is-5">Celular: </p>
            <p class="subtitle">{{clientes.celular}}</p>
          </div>
        </div>
        <div class="column">
          <div class="box">
            <p class="title is-5">E-mail: </p>
            <p class="subtitle">{{clientes.email}}</p>
          </div>
          <div class="box">
            <p class="title is-5">Endereço: </p>
            <p class="subtitle">{{clientes.endereco}}</p>
          </div>
        </div>
      </div>
    </template>
  </section>
</template>

<script>
import axios from 'axios'
export default {
  data () {
    return {
      clientes: [],
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
    getEncomendas () {
      axios.get('http://localhost:5000/api/encomenda/' + this.clienteid).then(ret => {
        this.encomendas = ret.data
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
    console.log(this.GetEncomendas)
    // this.getCliente()
    this.getEncomendas()
    this.clienteid = this.$route.params.id
    axios.get('http://localhost:5000/api/cliente/' + this.clienteid).then(ret => {
      this.clientes = ret.data
    })
  }
}
</script>
