<template>
  <section>
    <div class="columns">
      <div class="column">
        <div class="box">
          <p class="title is-5">Doce:</p>
          <div class="select is-rounded">
            <select v-model="select">
              <option
                    v-for="option in tpdoce"
                    :value="option.id"
                    :key="option.id">
                    {{ option.nomeProduto}}
                </option>
            </select>
          </div>
        </div>
        <div class="box">
          <p class="title is-5">Sabor:</p>
          <div class="select is-rounded">
            <select select v-model="encomenda.idDoce">
              <option
                    v-for="option in doce"
                    :value="option.id"
                    :key="option.id"
                    @select="option => this.enconcomenda.idDoce = option.id">
                    {{ option.sabor}}
                </option>
            </select>
          </div>
        </div>
      </div>
      <div class="column">
        <div class="box">
          <p class="title is-5">Quantidade:</p>
          <b-input v-model="encomenda.quantidade"></b-input>
        </div>
        <div class="box">
          <p class="title is-5">Data de entrega:</p>
          <b-datepicker
            placeholder="Selecione uma data de entrega"
            icon="calendar-today"
            trap-focus
            v-model="encomenda.entrega"
          ></b-datepicker>
        </div>
      </div>
    </div>
    <div class="columns">
      <div class="column is-narrow">
        <div class="box" style="width: 200px;">
          <p class="title is-5">Preço:</p>
          <b-input v-model="encomenda.preco"></b-input>
        </div>
        <b-button type="is-primary"  @click="adicionarEncomenda" icon-left="plus">Salvar encomenda</b-button>
      </div>
    </div>
  </section>
</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      encomenda: {
        idCliente: null,
        idDoce: null,
        quantidade: null,
        preco: null,
        entrega: new Date()
      },
      tpdoce: [],
      doce: [],
      clientes: [],
      select: ''
    }
  },
  methods: {
    // getCliente () {
    //   axios.get('http://localhost:5000/api/cliente/' + this.clienteid).then(ret => {
    //     this.clientes = ret.data
    //   })
    // },
    getDoce () {
      axios.get('http://localhost:5000/api/doce').then(ret => {
        this.doce = ret.data
      })
    },
    getTpDoce () {
      axios.get('http://localhost:5000/api/tpdoce').then(ret => {
        this.tpdoce = ret.data
      })
    },
    adicionarEncomenda () {
      this.isLoading = true
      // this.encomenda.quantidade = parseInt(this.encomenda.quantidade)
      // this.encomenda.preco = parseFloat(this.encomenda.preco)
      this.encomenda.idCliente = this.clientes.id
      axios.post('http://localhost:5000/api/encomenda').then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Encomenda adicionada com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao adicionar o cliente.',
          type: 'is-error'
        })
      })
      console.log(this.encomenda)
    }
  },
  mounted () {
    this.clienteid = this.$route.params.id
    axios.get('http://localhost:5000/api/cliente/' + this.clienteid).then(ret => {
      this.clientes = ret.data
    })
    this.getDoce()
    this.getTpDoce()
    // console.log(this.doce)
  }
}
</script>
