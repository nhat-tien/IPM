<script lang="ts">
  import Home from './pages/Home.svelte';
  import About from './pages/About.svelte';
  import { Router, Link, Route } from "svelte-routing";


</script>

<Router>
  <nav>
    <Link to="/">Home</Link>
    <Link to="/about">About</Link>
  </nav>
  <main>
    <Route path="/" component={Home}></Route>
    <Route path="/about" component={About}></Route>
  </main>
</Router>

