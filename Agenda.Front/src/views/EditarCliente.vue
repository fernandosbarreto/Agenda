<template>
    <section>
      <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
      <div class="px-4 py-4" style="max-width: 400px">
        <span class="is-size-4">Editar Cliente</span>
        <b-field label="Nome" class="pt-5">
            <b-input v-model="cliente.nome"></b-input>
        </b-field>
        <b-field label="Sobrenome">
            <b-input v-model="cliente.sobrenome"></b-input>
        </b-field>
        <b-field label="Data de Nascimento">
          <b-datepicker
              placeholder="Selecione a data de nascimento"
              icon="calendar-today"
              v-model="nascimento"
              trap-focus>
          </b-datepicker>
        </b-field>

        <b-button class="mt-4" icon-left="account-plus" type="is-primary" @click="alterarCliente">Alterar</b-button>
    </div>
    </section>

</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      isLoading: false,
      clienteid: '',
      cliente: {
        nome: '',
        sobrenome: '',
        nascimento: new Date()
      }
    }
  },
  computed: {
    nascimento: {
      get () {
        return new Date(this.cliente.nascimento)
      },
      set (val) {
        this.cliente.nascimento = val
      }
    }
  },
  mounted () {
    this.isLoading = true
    this.clienteid = this.$route.params.id
    axios.get('http://localhost:5000/api/cliente/' + this.clienteid).then(ret => {
      this.cliente = ret.data
      this.isLoading = false
    }).catch(() => {
      this.isLoading = false
      this.$buefy.toast.open({
        message: 'cliente não encontrada.',
        type: 'is-danger'
      })
      this.$router.push('/')
    })
  },
  methods: {
    alterarCliente () {
      this.isLoading = true

      axios.put('http://localhost:5000/api/cliente/' + this.clienteid, this.cliente).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Cliente alterada com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao alterar a pesosa.',
          type: 'is-danger'
        })
      })
    }
  }
}
</script>
