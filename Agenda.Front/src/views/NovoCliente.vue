<template>
    <section>
      <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
      <div class="px-4 py-4" style="max-width: 400px">
        <span class="is-size-4">Novo Cliente</span>
        <b-field label="Nome" class="pt-5">
            <b-input v-model="cliente.nome"></b-input>
        </b-field>
        <b-field label="Sobrenome">
            <b-input v-model="cliente.sobrenome"></b-input>
        </b-field>
        <b-field label="Telefone">
            <b-input v-model="cliente.telefone"></b-input>
        </b-field>
        <b-field label="Celular">
            <b-input v-model="cliente.celular"></b-input>
        </b-field>
        <b-field label="E-mail">
            <b-input v-model="cliente.email"></b-input>
        </b-field>
        <b-field label="Endereço">
          <b-input v-model="cliente.endereco"></b-input>
        </b-field>

        <b-button class="mt-4" icon-left="account-plus" type="is-primary" @click="adicionarCliente">Adicionar</b-button>
    </div>
    </section>

</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      isLoading: false,
      cliente: {
        nome: '',
        sobrenome: '',
        telefone: '',
        celular: '',
        email: '',
        endereco: ''
      }
    }
  },
  methods: {
    adicionarCliente () {
      this.isLoading = true
      this.cliente.telefone = parseInt(this.cliente.telefone)
      this.cliente.celular = parseInt(this.cliente.celular)
      axios.post('http://localhost:5000/api/cliente', this.cliente).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Cliente adicionado com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao adicionar o cliente.',
          type: 'is-error'
        })
      })
    }
  }
}
</script>
