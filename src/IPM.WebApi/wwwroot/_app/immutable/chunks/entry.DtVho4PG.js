var Jt=t=>{throw TypeError(t)};var $e=(t,e,n)=>e.has(t)||Jt("Cannot "+n);var k=(t,e,n)=>($e(t,e,"read from private field"),n?n.call(t):e.get(t)),x=(t,e,n)=>e.has(t)?Jt("Cannot add the same private member more than once"):e instanceof WeakSet?e.add(t):e.set(t,n);import{a3 as O,j as C,ab as N,aJ as De}from"./runtime.CGf5uJ7Y.js";import{w as $t}from"./index.RlJIb4jq.js";import{o as zt}from"./index-client.CUomOBpI.js";new URL("sveltekit-internal://");function Fe(t,e){return t==="/"||e==="ignore"?t:e==="never"?t.endsWith("/")?t.slice(0,-1):t:e==="always"&&!t.endsWith("/")?t+"/":t}function Ve(t){return t.split("%25").map(decodeURI).join("%25")}function Be(t){for(const e in t)t[e]=decodeURIComponent(t[e]);return t}function Lt({href:t}){return t.split("#")[0]}function Ge(t,e,n,r=!1){const a=new URL(t);Object.defineProperty(a,"searchParams",{value:new Proxy(a.searchParams,{get(i,s){if(s==="get"||s==="getAll"||s==="has")return f=>(n(f),i[s](f));e();const c=Reflect.get(i,s);return typeof c=="function"?c.bind(i):c}}),enumerable:!0,configurable:!0});const o=["href","pathname","search","toString","toJSON"];r&&o.push("hash");for(const i of o)Object.defineProperty(a,i,{get(){return e(),t[i]},enumerable:!0,configurable:!0});return a}const Me="/__data.json",qe=".html__data.json";function He(t){return t.endsWith(".html")?t.replace(/\.html$/,qe):t.replace(/\/$/,"")+Me}function Ke(...t){let e=5381;for(const n of t)if(typeof n=="string"){let r=n.length;for(;r;)e=e*33^n.charCodeAt(--r)}else if(ArrayBuffer.isView(n)){const r=new Uint8Array(n.buffer,n.byteOffset,n.byteLength);let a=r.length;for(;a;)e=e*33^r[--a]}else throw new TypeError("value must be a string or TypedArray");return(e>>>0).toString(36)}function We(t){const e=atob(t),n=new Uint8Array(e.length);for(let r=0;r<e.length;r++)n[r]=e.charCodeAt(r);return n.buffer}const ue=window.fetch;window.fetch=(t,e)=>((t instanceof Request?t.method:(e==null?void 0:e.method)||"GET")!=="GET"&&Y.delete(Dt(t)),ue(t,e));const Y=new Map;function Ye(t,e){const n=Dt(t,e),r=document.querySelector(n);if(r!=null&&r.textContent){let{body:a,...o}=JSON.parse(r.textContent);const i=r.getAttribute("data-ttl");return i&&Y.set(n,{body:a,init:o,ttl:1e3*Number(i)}),r.getAttribute("data-b64")!==null&&(a=We(a)),Promise.resolve(new Response(a,o))}return window.fetch(t,e)}function Je(t,e,n){if(Y.size>0){const r=Dt(t,n),a=Y.get(r);if(a){if(performance.now()<a.ttl&&["default","force-cache","only-if-cached",void 0].includes(n==null?void 0:n.cache))return new Response(a.body,a.init);Y.delete(r)}}return window.fetch(e,n)}function Dt(t,e){let r=`script[data-sveltekit-fetched][data-url=${JSON.stringify(t instanceof Request?t.url:t)}]`;if(e!=null&&e.headers||e!=null&&e.body){const a=[];e.headers&&a.push([...new Headers(e.headers)].join(",")),e.body&&(typeof e.body=="string"||ArrayBuffer.isView(e.body))&&a.push(e.body),r+=`[data-hash="${Ke(...a)}"]`}return r}const ze=/^(\[)?(\.\.\.)?(\w+)(?:=(\w+))?(\])?$/;function Xe(t){const e=[];return{pattern:t==="/"?/^\/$/:new RegExp(`^${Qe(t).map(r=>{const a=/^\[\.\.\.(\w+)(?:=(\w+))?\]$/.exec(r);if(a)return e.push({name:a[1],matcher:a[2],optional:!1,rest:!0,chained:!0}),"(?:/(.*))?";const o=/^\[\[(\w+)(?:=(\w+))?\]\]$/.exec(r);if(o)return e.push({name:o[1],matcher:o[2],optional:!0,rest:!1,chained:!0}),"(?:/([^/]+))?";if(!r)return;const i=r.split(/\[(.+?)\](?!\])/);return"/"+i.map((c,f)=>{if(f%2){if(c.startsWith("x+"))return Tt(String.fromCharCode(parseInt(c.slice(2),16)));if(c.startsWith("u+"))return Tt(String.fromCharCode(...c.slice(2).split("-").map(l=>parseInt(l,16))));const h=ze.exec(c),[,d,y,u,g]=h;return e.push({name:u,matcher:g,optional:!!d,rest:!!y,chained:y?f===1&&i[0]==="":!1}),y?"(.*?)":d?"([^/]*)?":"([^/]+?)"}return Tt(c)}).join("")}).join("")}/?$`),params:e}}function Ze(t){return!/^\([^)]+\)$/.test(t)}function Qe(t){return t.slice(1).split("/").filter(Ze)}function tn(t,e,n){const r={},a=t.slice(1),o=a.filter(s=>s!==void 0);let i=0;for(let s=0;s<e.length;s+=1){const c=e[s];let f=a[s-i];if(c.chained&&c.rest&&i&&(f=a.slice(s-i,s+1).filter(h=>h).join("/"),i=0),f===void 0){c.rest&&(r[c.name]="");continue}if(!c.matcher||n[c.matcher](f)){r[c.name]=f;const h=e[s+1],d=a[s+1];h&&!h.rest&&h.optional&&d&&c.chained&&(i=0),!h&&!d&&Object.keys(r).length===o.length&&(i=0);continue}if(c.optional&&c.chained){i++;continue}return}if(!i)return r}function Tt(t){return t.normalize().replace(/[[\]]/g,"\\$&").replace(/%/g,"%25").replace(/\//g,"%2[Ff]").replace(/\?/g,"%3[Ff]").replace(/#/g,"%23").replace(/[.*+?^${}()|\\]/g,"\\$&")}function en({nodes:t,server_loads:e,dictionary:n,matchers:r}){const a=new Set(e);return Object.entries(n).map(([s,[c,f,h]])=>{const{pattern:d,params:y}=Xe(s),u={id:s,exec:g=>{const l=d.exec(g);if(l)return tn(l,y,r)},errors:[1,...h||[]].map(g=>t[g]),layouts:[0,...f||[]].map(i),leaf:o(c)};return u.errors.length=u.layouts.length=Math.max(u.errors.length,u.layouts.length),u});function o(s){const c=s<0;return c&&(s=~s),[c,t[s]]}function i(s){return s===void 0?s:[a.has(s),t[s]]}}function he(t,e=JSON.parse){try{return e(sessionStorage[t])}catch{}}function Xt(t,e,n=JSON.stringify){const r=n(e);try{sessionStorage[t]=r}catch{}}var se;const P=((se=globalThis.__sveltekit_i80b79)==null?void 0:se.base)??"";var ie;const nn=((ie=globalThis.__sveltekit_i80b79)==null?void 0:ie.assets)??P,rn="1736960766830",de="sveltekit:snapshot",pe="sveltekit:scroll",ge="sveltekit:states",an="sveltekit:pageurl",G="sveltekit:history",z="sveltekit:navigation",ut={tap:1,hover:2,viewport:3,eager:4,off:-1,false:-1},ft=location.origin;function me(t){if(t instanceof URL)return t;let e=document.baseURI;if(!e){const n=document.getElementsByTagName("base");e=n.length?n[0].href:document.URL}return new URL(t,e)}function Ft(){return{x:pageXOffset,y:pageYOffset}}function V(t,e){return t.getAttribute(`data-sveltekit-${e}`)}const Zt={...ut,"":ut.hover};function ye(t){let e=t.assignedSlot??t.parentNode;return(e==null?void 0:e.nodeType)===11&&(e=e.host),e}function _e(t,e){for(;t&&t!==e;){if(t.nodeName.toUpperCase()==="A"&&t.hasAttribute("href"))return t;t=ye(t)}}function Ct(t,e,n){let r;try{r=new URL(t instanceof SVGAElement?t.href.baseVal:t.href,document.baseURI)}catch{}const a=t instanceof SVGAElement?t.target.baseVal:t.target,o=!r||!!a||vt(r,e,n)||(t.getAttribute("rel")||"").split(/\s+/).includes("external"),i=(r==null?void 0:r.origin)===ft&&t.hasAttribute("download");return{url:r,external:o,target:a,download:i}}function ht(t){let e=null,n=null,r=null,a=null,o=null,i=null,s=t;for(;s&&s!==document.documentElement;)r===null&&(r=V(s,"preload-code")),a===null&&(a=V(s,"preload-data")),e===null&&(e=V(s,"keepfocus")),n===null&&(n=V(s,"noscroll")),o===null&&(o=V(s,"reload")),i===null&&(i=V(s,"replacestate")),s=ye(s);function c(f){switch(f){case"":case"true":return!0;case"off":case"false":return!1;default:return}}return{preload_code:Zt[r??"off"],preload_data:Zt[a??"off"],keepfocus:c(e),noscroll:c(n),reload:c(o),replace_state:c(i)}}function Qt(t){const e=$t(t);let n=!0;function r(){n=!0,e.update(i=>i)}function a(i){n=!1,e.set(i)}function o(i){let s;return e.subscribe(c=>{(s===void 0||n&&c!==s)&&i(s=c)})}return{notify:r,set:a,subscribe:o}}const we={v:()=>{}};function on(){const{set:t,subscribe:e}=$t(!1);let n;async function r(){clearTimeout(n);try{const a=await fetch(`${nn}/_app/version.json`,{headers:{pragma:"no-cache","cache-control":"no-cache"}});if(!a.ok)return!1;const i=(await a.json()).version!==rn;return i&&(t(!0),we.v(),clearTimeout(n)),i}catch{return!1}}return{subscribe:e,check:r}}function vt(t,e,n){return t.origin!==ft||!t.pathname.startsWith(e)?!0:n?!(t.pathname===e+"/"||t.protocol==="file:"&&t.pathname.replace(/\/[^/]+\.html?$/,"")===e):!1}function te(t){const e=cn(t),n=new ArrayBuffer(e.length),r=new DataView(n);for(let a=0;a<n.byteLength;a++)r.setUint8(a,e.charCodeAt(a));return n}const sn="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";function cn(t){t.length%4===0&&(t=t.replace(/==?$/,""));let e="",n=0,r=0;for(let a=0;a<t.length;a++)n<<=6,n|=sn.indexOf(t[a]),r+=6,r===24&&(e+=String.fromCharCode((n&16711680)>>16),e+=String.fromCharCode((n&65280)>>8),e+=String.fromCharCode(n&255),n=r=0);return r===12?(n>>=4,e+=String.fromCharCode(n)):r===18&&(n>>=2,e+=String.fromCharCode((n&65280)>>8),e+=String.fromCharCode(n&255)),e}const ln=-1,fn=-2,un=-3,hn=-4,dn=-5,pn=-6;function gn(t,e){if(typeof t=="number")return a(t,!0);if(!Array.isArray(t)||t.length===0)throw new Error("Invalid input");const n=t,r=Array(n.length);function a(o,i=!1){if(o===ln)return;if(o===un)return NaN;if(o===hn)return 1/0;if(o===dn)return-1/0;if(o===pn)return-0;if(i)throw new Error("Invalid input");if(o in r)return r[o];const s=n[o];if(!s||typeof s!="object")r[o]=s;else if(Array.isArray(s))if(typeof s[0]=="string"){const c=s[0],f=e==null?void 0:e[c];if(f)return r[o]=f(a(s[1]));switch(c){case"Date":r[o]=new Date(s[1]);break;case"Set":const h=new Set;r[o]=h;for(let u=1;u<s.length;u+=1)h.add(a(s[u]));break;case"Map":const d=new Map;r[o]=d;for(let u=1;u<s.length;u+=2)d.set(a(s[u]),a(s[u+1]));break;case"RegExp":r[o]=new RegExp(s[1],s[2]);break;case"Object":r[o]=Object(s[1]);break;case"BigInt":r[o]=BigInt(s[1]);break;case"null":const y=Object.create(null);r[o]=y;for(let u=1;u<s.length;u+=2)y[s[u]]=a(s[u+1]);break;case"Int8Array":case"Uint8Array":case"Uint8ClampedArray":case"Int16Array":case"Uint16Array":case"Int32Array":case"Uint32Array":case"Float32Array":case"Float64Array":case"BigInt64Array":case"BigUint64Array":{const u=globalThis[c],g=s[1],l=te(g),p=new u(l);r[o]=p;break}case"ArrayBuffer":{const u=s[1],g=te(u);r[o]=g;break}default:throw new Error(`Unknown type ${c}`)}}else{const c=new Array(s.length);r[o]=c;for(let f=0;f<s.length;f+=1){const h=s[f];h!==fn&&(c[f]=a(h))}}else{const c={};r[o]=c;for(const f in s){const h=s[f];c[f]=a(h)}}return r[o]}return a(0)}const ve=new Set(["load","prerender","csr","ssr","trailingSlash","config"]);[...ve];const mn=new Set([...ve]);[...mn];function yn(t){return t.filter(e=>e!=null)}class bt{constructor(e,n){this.status=e,typeof n=="string"?this.body={message:n}:n?this.body=n:this.body={message:`Error: ${e}`}}toString(){return JSON.stringify(this.body)}}class be{constructor(e,n){this.status=e,this.location=n}}class Vt extends Error{constructor(e,n,r){super(r),this.status=e,this.text=n}}const _n="x-sveltekit-invalidated",wn="x-sveltekit-trailing-slash";function dt(t){return t instanceof bt||t instanceof Vt?t.status:500}function vn(t){return t instanceof Vt?t.text:"Internal Error"}let b,X,Pt;const bn=zt.toString().includes("$$")||/function \w+\(\) \{\}/.test(zt.toString());var tt,et,nt,rt,at,ot,st,it,ce,ct,le,lt,fe;bn?(b={data:{},form:null,error:null,params:{},route:{id:null},state:{},status:-1,url:new URL("https://example.com")},X={current:null},Pt={current:!1}):(b=new(ce=class{constructor(){x(this,tt,O({}));x(this,et,O(null));x(this,nt,O(null));x(this,rt,O({}));x(this,at,O({id:null}));x(this,ot,O({}));x(this,st,O(-1));x(this,it,O(new URL("https://example.com")))}get data(){return C(k(this,tt))}set data(e){N(k(this,tt),e)}get form(){return C(k(this,et))}set form(e){N(k(this,et),e)}get error(){return C(k(this,nt))}set error(e){N(k(this,nt),e)}get params(){return C(k(this,rt))}set params(e){N(k(this,rt),e)}get route(){return C(k(this,at))}set route(e){N(k(this,at),e)}get state(){return C(k(this,ot))}set state(e){N(k(this,ot),e)}get status(){return C(k(this,st))}set status(e){N(k(this,st),e)}get url(){return C(k(this,it))}set url(e){N(k(this,it),e)}},tt=new WeakMap,et=new WeakMap,nt=new WeakMap,rt=new WeakMap,at=new WeakMap,ot=new WeakMap,st=new WeakMap,it=new WeakMap,ce),X=new(le=class{constructor(){x(this,ct,O(null))}get current(){return C(k(this,ct))}set current(e){N(k(this,ct),e)}},ct=new WeakMap,le),Pt=new(fe=class{constructor(){x(this,lt,O(!1))}get current(){return C(k(this,lt))}set current(e){N(k(this,lt),e)}},lt=new WeakMap,fe),we.v=()=>Pt.current=!0);function ke(t){Object.assign(b,t)}const kn=new Set(["icon","shortcut icon","apple-touch-icon"]),F=he(pe)??{},Z=he(de)??{},$={url:Qt({}),page:Qt({}),navigating:$t(null),updated:on()};function Bt(t){F[t]=Ft()}function An(t,e){let n=t+1;for(;F[n];)delete F[n],n+=1;for(n=e+1;Z[n];)delete Z[n],n+=1}function q(t){return location.href=t.href,new Promise(()=>{})}async function Ae(){if("serviceWorker"in navigator){const t=await navigator.serviceWorker.getRegistration(P||"/");t&&await t.update()}}function ee(){}let kt,Nt,pt,j,jt,S;const gt=[],mt=[];let L=null;const Se=[],Sn=[];let B=[],_={branch:[],error:null,url:null},Gt=!1,yt=!1,ne=!0,Q=!1,K=!1,Ee=!1,At=!1,St,U,T,H;const J=new Set;let xt;async function Vn(t,e,n){var a,o,i,s;document.URL!==location.href&&(location.href=location.href),S=t,await((o=(a=t.hooks).init)==null?void 0:o.call(a)),kt=en(t),j=document.documentElement,jt=e,Nt=t.nodes[0],pt=t.nodes[1],Nt(),pt(),U=(i=history.state)==null?void 0:i[G],T=(s=history.state)==null?void 0:s[z],U||(U=T=Date.now(),history.replaceState({...history.state,[G]:U,[z]:T},""));const r=F[U];r&&(history.scrollRestoration="manual",scrollTo(r.x,r.y)),n?await Pn(jt,n):Ln(location.href,{replaceState:!0}),Tn()}async function Re(){if(await(xt||(xt=Promise.resolve())),!xt)return;xt=null;const t=Rt(_.url,!0);L=null;const e=H={},n=t&&await Kt(t);if(!(!n||e!==H)){if(n.type==="redirect")return Mt(new URL(n.location,_.url).href,{},1,e);n.props.page&&Object.assign(b,n.props.page),_=n.state,Ie(),St.$set(n.props),ke(n.props.page)}}function Ie(){gt.length=0,At=!1}function Ue(t){mt.some(e=>e==null?void 0:e.snapshot)&&(Z[t]=mt.map(e=>{var n;return(n=e==null?void 0:e.snapshot)==null?void 0:n.capture()}))}function Le(t){var e;(e=Z[t])==null||e.forEach((n,r)=>{var a,o;(o=(a=mt[r])==null?void 0:a.snapshot)==null||o.restore(n)})}function re(){Bt(U),Xt(pe,F),Ue(T),Xt(de,Z)}async function Mt(t,e,n,r){return W({type:"goto",url:me(t),keepfocus:e.keepFocus,noscroll:e.noScroll,replace_state:e.replaceState,state:e.state,redirect_count:n,nav_token:r,accept:()=>{e.invalidateAll&&(At=!0)}})}async function En(t){if(t.id!==(L==null?void 0:L.id)){const e={};J.add(e),L={id:t.id,token:e,promise:Kt({...t,preload:e}).then(n=>(J.delete(e),n.type==="loaded"&&n.state.error&&(L=null),n))}}return L.promise}async function Ot(t){const e=kt.find(n=>n.exec(Pe(t)));e&&await Promise.all([...e.layouts,e.leaf].map(n=>n==null?void 0:n[1]()))}function Te(t,e,n){var o;_=t.state;const r=document.querySelector("style[data-sveltekit]");r&&r.remove(),Object.assign(b,t.props.page),St=new S.root({target:e,props:{...t.props,stores:$,components:mt},hydrate:n,sync:!1}),Le(T);const a={from:null,to:{params:_.params,route:{id:((o=_.route)==null?void 0:o.id)??null},url:new URL(location.href)},willUnload:!1,type:"enter",complete:Promise.resolve()};B.forEach(i=>i(a)),yt=!0}function _t({url:t,params:e,branch:n,status:r,error:a,route:o,form:i}){let s="never";if(P&&(t.pathname===P||t.pathname===P+"/"))s="always";else for(const u of n)(u==null?void 0:u.slash)!==void 0&&(s=u.slash);t.pathname=Fe(t.pathname,s),t.search=t.search;const c={type:"loaded",state:{url:t,params:e,branch:n,error:a,route:o},props:{constructors:yn(n).map(u=>u.node.component),page:b}};i!==void 0&&(c.props.form=i);let f={},h=!b,d=0;for(let u=0;u<Math.max(n.length,_.branch.length);u+=1){const g=n[u],l=_.branch[u];(g==null?void 0:g.data)!==(l==null?void 0:l.data)&&(h=!0),g&&(f={...f,...g.data},h&&(c.props[`data_${d}`]=f),d+=1)}return(!_.url||t.href!==_.url.href||_.error!==a||i!==void 0&&i!==b.form||h)&&(c.props.page={error:a,params:e,route:{id:(o==null?void 0:o.id)??null},state:{},status:r,url:new URL(t),form:i??null,data:h?f:b.data}),c}async function qt({loader:t,parent:e,url:n,params:r,route:a,server_data_node:o}){var h,d,y;let i=null,s=!0;const c={dependencies:new Set,params:new Set,parent:!1,route:!1,url:!1,search_params:new Set},f=await t();if((h=f.universal)!=null&&h.load){let u=function(...l){for(const p of l){const{href:A}=new URL(p,n);c.dependencies.add(A)}};const g={route:new Proxy(a,{get:(l,p)=>(s&&(c.route=!0),l[p])}),params:new Proxy(r,{get:(l,p)=>(s&&c.params.add(p),l[p])}),data:(o==null?void 0:o.data)??null,url:Ge(n,()=>{s&&(c.url=!0)},l=>{s&&c.search_params.add(l)},S.hash),async fetch(l,p){let A;l instanceof Request?(A=l.url,p={body:l.method==="GET"||l.method==="HEAD"?void 0:await l.blob(),cache:l.cache,credentials:l.credentials,headers:[...l.headers].length?l.headers:void 0,integrity:l.integrity,keepalive:l.keepalive,method:l.method,mode:l.mode,redirect:l.redirect,referrer:l.referrer,referrerPolicy:l.referrerPolicy,signal:l.signal,...p}):A=l;const R=new URL(A,n);return s&&u(R.href),R.origin===n.origin&&(A=R.href.slice(n.origin.length)),yt?Je(A,R.href,p):Ye(A,p)},setHeaders:()=>{},depends:u,parent(){return s&&(c.parent=!0),e()},untrack(l){s=!1;try{return l()}finally{s=!0}}};i=await f.universal.load.call(null,g)??null}return{node:f,loader:t,server:o,universal:(d=f.universal)!=null&&d.load?{type:"data",data:i,uses:c}:null,data:i??(o==null?void 0:o.data)??null,slash:((y=f.universal)==null?void 0:y.trailingSlash)??(o==null?void 0:o.slash)}}function ae(t,e,n,r,a,o){if(At)return!0;if(!a)return!1;if(a.parent&&t||a.route&&e||a.url&&n)return!0;for(const i of a.search_params)if(r.has(i))return!0;for(const i of a.params)if(o[i]!==_.params[i])return!0;for(const i of a.dependencies)if(gt.some(s=>s(new URL(i))))return!0;return!1}function Ht(t,e){return(t==null?void 0:t.type)==="data"?t:(t==null?void 0:t.type)==="skip"?e??null:null}function Rn(t,e){if(!t)return new Set(e.searchParams.keys());const n=new Set([...t.searchParams.keys(),...e.searchParams.keys()]);for(const r of n){const a=t.searchParams.getAll(r),o=e.searchParams.getAll(r);a.every(i=>o.includes(i))&&o.every(i=>a.includes(i))&&n.delete(r)}return n}function oe({error:t,url:e,route:n,params:r}){return{type:"loaded",state:{error:t,url:e,route:n,params:r,branch:[]},props:{page:b,constructors:[]}}}async function Kt({id:t,invalidating:e,url:n,params:r,route:a,preload:o}){if((L==null?void 0:L.id)===t)return J.delete(L.token),L.promise;const{errors:i,layouts:s,leaf:c}=a,f=[...s,c];i.forEach(m=>m==null?void 0:m().catch(()=>{})),f.forEach(m=>m==null?void 0:m[1]().catch(()=>{}));let h=null;const d=_.url?t!==wt(_.url):!1,y=_.route?a.id!==_.route.id:!1,u=Rn(_.url,n);let g=!1;const l=f.map((m,v)=>{var D;const E=_.branch[v],I=!!(m!=null&&m[0])&&((E==null?void 0:E.loader)!==m[1]||ae(g,y,d,u,(D=E.server)==null?void 0:D.uses,r));return I&&(g=!0),I});if(l.some(Boolean)){try{h=await Ce(n,l)}catch(m){const v=await M(m,{url:n,params:r,route:{id:t}});return J.has(o)?oe({error:v,url:n,params:r,route:a}):Et({status:dt(m),error:v,url:n,route:a})}if(h.type==="redirect")return h}const p=h==null?void 0:h.nodes;let A=!1;const R=f.map(async(m,v)=>{var It;if(!m)return;const E=_.branch[v],I=p==null?void 0:p[v];if((!I||I.type==="skip")&&m[1]===(E==null?void 0:E.loader)&&!ae(A,y,d,u,(It=E.universal)==null?void 0:It.uses,r))return E;if(A=!0,(I==null?void 0:I.type)==="error")throw I;return qt({loader:m[1],url:n,params:r,route:a,parent:async()=>{var Yt;const Wt={};for(let Ut=0;Ut<v;Ut+=1)Object.assign(Wt,(Yt=await R[Ut])==null?void 0:Yt.data);return Wt},server_data_node:Ht(I===void 0&&m[0]?{type:"skip"}:I??null,m[0]?E==null?void 0:E.server:void 0)})});for(const m of R)m.catch(()=>{});const w=[];for(let m=0;m<f.length;m+=1)if(f[m])try{w.push(await R[m])}catch(v){if(v instanceof be)return{type:"redirect",location:v.location};if(J.has(o))return oe({error:await M(v,{params:r,url:n,route:{id:a.id}}),url:n,params:r,route:a});let E=dt(v),I;if(p!=null&&p.includes(v))E=v.status??E,I=v.error;else if(v instanceof bt)I=v.body;else{if(await $.updated.check())return await Ae(),await q(n);I=await M(v,{params:r,url:n,route:{id:a.id}})}const D=await In(m,w,i);return D?_t({url:n,params:r,branch:w.slice(0,D.idx).concat(D.node),status:E,error:I,route:a}):await Oe(n,{id:a.id},I,E)}else w.push(void 0);return _t({url:n,params:r,branch:w,status:200,error:null,route:a,form:e?void 0:null})}async function In(t,e,n){for(;t--;)if(n[t]){let r=t;for(;!e[r];)r-=1;try{return{idx:r+1,node:{node:await n[t](),loader:n[t],data:{},server:null,universal:null}}}catch{continue}}}async function Et({status:t,error:e,url:n,route:r}){const a={};let o=null;if(S.server_loads[0]===0)try{const f=await Ce(n,[!0]);if(f.type!=="data"||f.nodes[0]&&f.nodes[0].type!=="data")throw 0;o=f.nodes[0]??null}catch{(n.origin!==ft||n.pathname!==location.pathname||Gt)&&await q(n)}const s=await qt({loader:Nt,url:n,params:a,route:r,parent:()=>Promise.resolve({}),server_data_node:Ht(o)}),c={node:await pt(),loader:pt,universal:null,server:null,data:null};return _t({url:n,params:a,branch:[s,c],status:t,error:e,route:null})}function Rt(t,e){if(!t||vt(t,P,S.hash))return;let n;try{if(n=S.hooks.reroute({url:new URL(t)})??t,typeof n=="string"){const a=new URL(t);S.hash?a.hash=n:a.pathname=n,n=a}}catch{return}const r=Pe(n);for(const a of kt){const o=a.exec(r);if(o)return{id:wt(t),invalidating:e,route:a,params:Be(o),url:t}}}function Pe(t){return Ve(S.hash?t.hash.replace(/^#/,"").replace(/[?#].+/,""):t.pathname.slice(P.length))||"/"}function wt(t){return(S.hash?t.hash.replace(/^#/,""):t.pathname)+t.search}function xe({url:t,type:e,intent:n,delta:r}){let a=!1;const o=je(_,n,t,e);r!==void 0&&(o.navigation.delta=r);const i={...o.navigation,cancel:()=>{a=!0,o.reject(new Error("navigation cancelled"))}};return Q||Se.forEach(s=>s(i)),a?null:o}async function W({type:t,url:e,popped:n,keepfocus:r,noscroll:a,replace_state:o,state:i={},redirect_count:s=0,nav_token:c={},accept:f=ee,block:h=ee}){const d=Rt(e,!1),y=xe({url:e,type:t,delta:n==null?void 0:n.delta,intent:d});if(!y){h();return}const u=U,g=T;f(),Q=!0,yt&&$.navigating.set(X.current=y.navigation),H=c;let l=d&&await Kt(d);if(!l){if(vt(e,P,S.hash))return await q(e);l=await Oe(e,{id:null},await M(new Vt(404,"Not Found",`Not found: ${e.pathname}`),{url:e,params:{},route:{id:null}}),404)}if(e=(d==null?void 0:d.url)||e,H!==c)return y.reject(new Error("navigation aborted")),!1;if(l.type==="redirect")if(s>=20)l=await Et({status:500,error:await M(new Error("Redirect loop"),{url:e,params:{},route:{id:null}}),url:e,route:{id:null}});else return Mt(new URL(l.location,e).href,{},s+1,c),!1;else l.props.page.status>=400&&await $.updated.check()&&(await Ae(),await q(e));if(Ie(),Bt(u),Ue(g),l.props.page.url.pathname!==e.pathname&&(e.pathname=l.props.page.url.pathname),i=n?n.state:i,!n){const w=o?0:1,m={[G]:U+=w,[z]:T+=w,[ge]:i};(o?history.replaceState:history.pushState).call(history,m,"",e),o||An(U,T)}if(L=null,l.props.page.state=i,yt){_=l.state,l.props.page&&(l.props.page.url=e);const w=(await Promise.all(Sn.map(m=>m(y.navigation)))).filter(m=>typeof m=="function");if(w.length>0){let m=function(){B=B.filter(v=>!w.includes(v))};w.push(m),B.push(...w)}St.$set(l.props),ke(l.props.page),Ee=!0}else Te(l,jt,!1);const{activeElement:p}=document;await De();const A=n?n.scroll:a?Ft():null;if(ne){const w=e.hash&&document.getElementById(decodeURIComponent(S.hash?e.hash.split("#")[2]??"":e.hash.slice(1)));A?scrollTo(A.x,A.y):w?w.scrollIntoView():scrollTo(0,0)}const R=document.activeElement!==p&&document.activeElement!==document.body;!r&&!R&&xn(),ne=!0,l.props.page&&Object.assign(b,l.props.page),Q=!1,t==="popstate"&&Le(T),y.fulfil(void 0),B.forEach(w=>w(y.navigation)),$.navigating.set(X.current=null)}async function Oe(t,e,n,r){return t.origin===ft&&t.pathname===location.pathname&&!Gt?await Et({status:r,error:n,url:t,route:e}):await q(t)}function Un(){let t;j.addEventListener("mousemove",o=>{const i=o.target;clearTimeout(t),t=setTimeout(()=>{r(i,2)},20)});function e(o){o.defaultPrevented||r(o.composedPath()[0],1)}j.addEventListener("mousedown",e),j.addEventListener("touchstart",e,{passive:!0});const n=new IntersectionObserver(o=>{for(const i of o)i.isIntersecting&&(Ot(new URL(i.target.href)),n.unobserve(i.target))},{threshold:0});function r(o,i){const s=_e(o,j);if(!s)return;const{url:c,external:f,download:h}=Ct(s,P,S.hash);if(f||h)return;const d=ht(s),y=c&&wt(_.url)===wt(c);if(!d.reload&&!y)if(i<=d.preload_data){const u=Rt(c,!1);u&&En(u)}else i<=d.preload_code&&Ot(c)}function a(){n.disconnect();for(const o of j.querySelectorAll("a")){const{url:i,external:s,download:c}=Ct(o,P,S.hash);if(s||c)continue;const f=ht(o);f.reload||(f.preload_code===ut.viewport&&n.observe(o),f.preload_code===ut.eager&&Ot(i))}}B.push(a),a()}function M(t,e){if(t instanceof bt)return t.body;const n=dt(t),r=vn(t);return S.hooks.handleError({error:t,event:e,status:n,message:r})??{message:r}}function Ln(t,e={}){return t=new URL(me(t)),t.origin!==ft?Promise.reject(new Error("goto: invalid URL")):Mt(t,e,0)}function Bn(t){if(typeof t=="function")gt.push(t);else{const{href:e}=new URL(t,location.href);gt.push(n=>n.href===e)}return Re()}function Gn(){return At=!0,Re()}function Tn(){var e;history.scrollRestoration="manual",addEventListener("beforeunload",n=>{let r=!1;if(re(),!Q){const a=je(_,void 0,null,"leave"),o={...a.navigation,cancel:()=>{r=!0,a.reject(new Error("navigation cancelled"))}};Se.forEach(i=>i(o))}r?(n.preventDefault(),n.returnValue=""):history.scrollRestoration="auto"}),addEventListener("visibilitychange",()=>{document.visibilityState==="hidden"&&re()}),(e=navigator.connection)!=null&&e.saveData||Un(),j.addEventListener("click",async n=>{if(n.button||n.which!==1||n.metaKey||n.ctrlKey||n.shiftKey||n.altKey||n.defaultPrevented)return;const r=_e(n.composedPath()[0],j);if(!r)return;const{url:a,external:o,target:i,download:s}=Ct(r,P,S.hash);if(!a)return;if(i==="_parent"||i==="_top"){if(window.parent!==window)return}else if(i&&i!=="_self")return;const c=ht(r);if(!(r instanceof SVGAElement)&&a.protocol!==location.protocol&&!(a.protocol==="https:"||a.protocol==="http:")||s)return;const[h,d]=(S.hash?a.hash.replace(/^#/,""):a.href).split("#"),y=h===Lt(location);if(o||c.reload&&(!y||!d)){xe({url:a,type:"link"})?Q=!0:n.preventDefault();return}if(d!==void 0&&y){const[,u]=_.url.href.split("#");if(u===d){if(n.preventDefault(),d===""||d==="top"&&r.ownerDocument.getElementById("top")===null)window.scrollTo({top:0});else{const g=r.ownerDocument.getElementById(decodeURIComponent(d));g&&(g.scrollIntoView(),g.focus())}return}if(K=!0,Bt(U),t(a),!c.replace_state)return;K=!1}n.preventDefault(),await new Promise(u=>{requestAnimationFrame(()=>{setTimeout(u,0)}),setTimeout(u,100)}),W({type:"link",url:a,keepfocus:c.keepfocus,noscroll:c.noscroll,replace_state:c.replace_state??a.href===location.href})}),j.addEventListener("submit",n=>{if(n.defaultPrevented)return;const r=HTMLFormElement.prototype.cloneNode.call(n.target),a=n.submitter;if(((a==null?void 0:a.formTarget)||r.target)==="_blank"||((a==null?void 0:a.formMethod)||r.method)!=="get")return;const s=new URL((a==null?void 0:a.hasAttribute("formaction"))&&(a==null?void 0:a.formAction)||r.action);if(vt(s,P,!1))return;const c=n.target,f=ht(c);if(f.reload)return;n.preventDefault(),n.stopPropagation();const h=new FormData(c),d=a==null?void 0:a.getAttribute("name");d&&h.append(d,(a==null?void 0:a.getAttribute("value"))??""),s.search=new URLSearchParams(h).toString(),W({type:"form",url:s,keepfocus:f.keepfocus,noscroll:f.noscroll,replace_state:f.replace_state??s.href===location.href})}),addEventListener("popstate",async n=>{var r;if((r=n.state)!=null&&r[G]){const a=n.state[G];if(H={},a===U)return;const o=F[a],i=n.state[ge]??{},s=new URL(n.state[an]??location.href),c=n.state[z],f=Lt(location)===Lt(_.url);if(c===T&&(Ee||f)){t(s),F[U]=Ft(),o&&scrollTo(o.x,o.y),i!==b.state&&(b.state=i,St.$set({page:b})),U=a;return}const d=a-U;await W({type:"popstate",url:s,popped:{state:i,scroll:o,delta:d},accept:()=>{U=a,T=c},block:()=>{history.go(-d)},nav_token:H})}else if(!K){const a=new URL(location.href);t(a)}}),addEventListener("hashchange",()=>{K?(K=!1,history.replaceState({...history.state,[G]:++U,[z]:T},"",location.href)):S.hash&&_.url.hash===location.hash&&W({type:"goto",url:_.url})});for(const n of document.querySelectorAll("link"))kn.has(n.rel)&&(n.href=n.href);addEventListener("pageshow",n=>{n.persisted&&$.navigating.set(X.current=null)});function t(n){_.url=b.url=n,$.page.set({data:b.data,error:b.error,form:b.form,params:b.params,route:b.route,state:b.state,status:b.status,url:n}),$.page.notify()}}async function Pn(t,{status:e=200,error:n,node_ids:r,params:a,route:o,data:i,form:s}){Gt=!0;const c=new URL(location.href);({params:a={},route:o={id:null}}=Rt(c,!1)||{});let f,h=!0;try{const d=r.map(async(g,l)=>{const p=i[l];return p!=null&&p.uses&&(p.uses=Ne(p.uses)),qt({loader:S.nodes[g],url:c,params:a,route:o,parent:async()=>{const A={};for(let R=0;R<l;R+=1)Object.assign(A,(await d[R]).data);return A},server_data_node:Ht(p)})}),y=await Promise.all(d),u=kt.find(({id:g})=>g===o.id);if(u){const g=u.layouts;for(let l=0;l<g.length;l++)g[l]||y.splice(l,0,void 0)}f=_t({url:c,params:a,branch:y,status:e,error:n,form:s,route:u??null})}catch(d){if(d instanceof be){await q(new URL(d.location,location.href));return}f=await Et({status:dt(d),error:await M(d,{url:c,params:a,route:o}),url:c,route:o}),t.textContent="",h=!1}f.props.page&&(f.props.page.state={}),Te(f,t,h)}async function Ce(t,e){var a;const n=new URL(t);n.pathname=He(t.pathname),t.pathname.endsWith("/")&&n.searchParams.append(wn,"1"),n.searchParams.append(_n,e.map(o=>o?"1":"0").join(""));const r=await ue(n.href);if(!r.ok){let o;throw(a=r.headers.get("content-type"))!=null&&a.includes("application/json")?o=await r.json():r.status===404?o="Not Found":r.status===500&&(o="Internal Error"),new bt(r.status,o)}return new Promise(async o=>{var d;const i=new Map,s=r.body.getReader(),c=new TextDecoder;function f(y){return gn(y,{...S.decoders,Promise:u=>new Promise((g,l)=>{i.set(u,{fulfil:g,reject:l})})})}let h="";for(;;){const{done:y,value:u}=await s.read();if(y&&!h)break;for(h+=!u&&h?`
`:c.decode(u,{stream:!0});;){const g=h.indexOf(`
`);if(g===-1)break;const l=JSON.parse(h.slice(0,g));if(h=h.slice(g+1),l.type==="redirect")return o(l);if(l.type==="data")(d=l.nodes)==null||d.forEach(p=>{(p==null?void 0:p.type)==="data"&&(p.uses=Ne(p.uses),p.data=f(p.data))}),o(l);else if(l.type==="chunk"){const{id:p,data:A,error:R}=l,w=i.get(p);i.delete(p),R?w.reject(f(R)):w.fulfil(f(A))}}}})}function Ne(t){return{dependencies:new Set((t==null?void 0:t.dependencies)??[]),params:new Set((t==null?void 0:t.params)??[]),parent:!!(t!=null&&t.parent),route:!!(t!=null&&t.route),url:!!(t!=null&&t.url),search_params:new Set((t==null?void 0:t.search_params)??[])}}function xn(){const t=document.querySelector("[autofocus]");if(t)t.focus();else{const e=document.body,n=e.getAttribute("tabindex");e.tabIndex=-1,e.focus({preventScroll:!0,focusVisible:!1}),n!==null?e.setAttribute("tabindex",n):e.removeAttribute("tabindex");const r=getSelection();if(r&&r.type!=="None"){const a=[];for(let o=0;o<r.rangeCount;o+=1)a.push(r.getRangeAt(o));setTimeout(()=>{if(r.rangeCount===a.length){for(let o=0;o<r.rangeCount;o+=1){const i=a[o],s=r.getRangeAt(o);if(i.commonAncestorContainer!==s.commonAncestorContainer||i.startContainer!==s.startContainer||i.endContainer!==s.endContainer||i.startOffset!==s.startOffset||i.endOffset!==s.endOffset)return}r.removeAllRanges()}})}}}function je(t,e,n,r){var c,f;let a,o;const i=new Promise((h,d)=>{a=h,o=d});return i.catch(()=>{}),{navigation:{from:{params:t.params,route:{id:((c=t.route)==null?void 0:c.id)??null},url:t.url},to:n&&{params:(e==null?void 0:e.params)??null,route:{id:((f=e==null?void 0:e.route)==null?void 0:f.id)??null},url:n},willUnload:!e,type:r,complete:i},fulfil:a,reject:o}}export{Bn as a,Ln as g,Gn as i,Vn as s};
