<template>
  <section>
    <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
    <div class="px-4 py-4">
          <div class="columns">
            <div class="column is-full">
              <p class="title is-5">Novo cliente</p>
            </div>
          </div>
          <div class="columns">
            <div class="column">
              <div class="box pt-5">
                <b-field label="Nome">
                  <b-input v-model="cliente.nome"></b-input>
                </b-field>
              </div>
              <div class="box">
                <b-field label="Sobrenome">
                  <b-input v-model="cliente.sobrenome"></b-input>
                </b-field>
              </div>
            </div>
            <div class="column">
              <div class="box">
                <b-field label="Telefone">
                  <b-input v-model="cliente.telefone"></b-input>
                </b-field>
              </div>
              <div class="box">
                <b-field label="Celular">
                  <b-input v-model="cliente.celular"></b-input>
                </b-field>
              </div>
            </div>
            <div class="column">
              <div class="box">
                <b-field label="E-mail">
                  <b-input v-model="cliente.email"></b-input>
                </b-field>
              </div>
              <div class="box">
                <b-field label="Endereço">
                  <b-input v-model="cliente.endereco"></b-input>
                </b-field>
              </div>
            </div>
          </div>
          <b-button class="mt-4" icon-left="account-plus" type="is-primary" @click="adicionarCliente">Adicionar</b-button>    </div>
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
