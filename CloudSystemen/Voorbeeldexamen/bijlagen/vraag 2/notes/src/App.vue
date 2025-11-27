<template>
  <div id="app">
    <h1>Notes</h1>
    <ul>
      <li v-for="note in notes" :key="note.id">{{ note.text }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'App',
  data() {
    return {
      notes: []
    }
  },
  created() {
    fetch('http://localhost:3000/notes')
      .then(response => response.json())
      .then(data => {
        this.notes = data;
      });
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
