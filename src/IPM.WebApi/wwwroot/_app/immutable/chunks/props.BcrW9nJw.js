import{S as N,a2 as $,a3 as z,L as w,a4 as H,_ as g,a5 as S,U as o,Z as y,w as j,a6 as V,a7 as J,l as Q,O as W,K as Z,n as U,a8 as X,a9 as k,aa as ee,ab as re,u as q,ac as ne,ad as te,ae as F,af as ie,ag as ae,ah as fe,ai as se,aj as G,ak as K,al as ue,am as le,an as D}from"./runtime.lGjdO0kn.js";import{s as ve}from"./index-client.0gGn_WSH.js";function m(e,n=null,f){if(typeof e!="object"||e===null||N in e)return e;const t=J(e);if(t!==$&&t!==z)return e;var i=new Map,_=Q(e),h=w(0);_&&i.set("length",w(e.length));var P;return new Proxy(e,{defineProperty(l,r,a){(!("value"in a)||a.configurable===!1||a.enumerable===!1||a.writable===!1)&&H();var u=i.get(r);return u===void 0?(u=w(a.value),i.set(r,u)):g(u,m(a.value,P)),!0},deleteProperty(l,r){var a=i.get(r);if(a===void 0)r in l&&i.set(r,w(o));else{if(_&&typeof r=="string"){var u=i.get("length"),s=Number(r);Number.isInteger(s)&&s<u.v&&g(u,s)}g(a,o),M(h)}return!0},get(l,r,a){var c;if(r===N)return e;var u=i.get(r),s=r in l;if(u===void 0&&(!s||(c=S(l,r))!=null&&c.writable)&&(u=w(m(s?l[r]:o,P)),i.set(r,u)),u!==void 0){var v=y(u);return v===o?void 0:v}return Reflect.get(l,r,a)},getOwnPropertyDescriptor(l,r){var a=Reflect.getOwnPropertyDescriptor(l,r);if(a&&"value"in a){var u=i.get(r);u&&(a.value=y(u))}else if(a===void 0){var s=i.get(r),v=s==null?void 0:s.v;if(s!==void 0&&v!==o)return{enumerable:!0,configurable:!0,value:v,writable:!0}}return a},has(l,r){var v;if(r===N)return!0;var a=i.get(r),u=a!==void 0&&a.v!==o||Reflect.has(l,r);if(a!==void 0||j!==null&&(!u||(v=S(l,r))!=null&&v.writable)){a===void 0&&(a=w(u?m(l[r],P):o),i.set(r,a));var s=y(a);if(s===o)return!1}return u},set(l,r,a,u){var O;var s=i.get(r),v=r in l;if(_&&r==="length")for(var c=a;c<s.v;c+=1){var I=i.get(c+"");I!==void 0?g(I,o):c in l&&(I=w(o),i.set(c+"",I))}s===void 0?(!v||(O=S(l,r))!=null&&O.writable)&&(s=w(void 0),g(s,m(a,P)),i.set(r,s)):(v=s.v!==o,g(s,m(a,P)));var b=Reflect.getOwnPropertyDescriptor(l,r);if(b!=null&&b.set&&b.set.call(u,a),!v){if(_&&typeof r=="string"){var E=i.get("length"),p=Number(r);Number.isInteger(p)&&p>=E.v&&g(E,p+1)}M(h)}return!0},ownKeys(l){y(h);var r=Reflect.ownKeys(l).filter(s=>{var v=i.get(s);return v===void 0||v.v!==o});for(var[a,u]of i)u.v!==o&&!(a in l)&&r.push(a);return r},setPrototypeOf(){V()}})}function M(e,n=1){g(e,e.v+n)}let L=!1;function be(e,n,f){const t=f[n]??(f[n]={store:null,source:Z(void 0),unsubscribe:U});if(t.store!==e)if(t.unsubscribe(),t.store=e??null,e==null)t.source.v=void 0,t.unsubscribe=U;else{var i=!0;t.unsubscribe=ve(e,_=>{i?t.source.v=_:g(t.source,_)}),i=!1}return y(t.source)}function ge(){const e={};return W(()=>{for(var n in e)e[n].unsubscribe()}),e}function de(e){var n=L;try{return L=!1,[e(),L]}finally{L=n}}const _e={get(e,n){let f=e.props.length;for(;f--;){let t=e.props[f];if(D(t)&&(t=t()),typeof t=="object"&&t!==null&&n in t)return t[n]}},set(e,n,f){let t=e.props.length;for(;t--;){let i=e.props[t];D(i)&&(i=i());const _=S(i,n);if(_&&_.set)return _.set(f),!0}return!1},getOwnPropertyDescriptor(e,n){let f=e.props.length;for(;f--;){let t=e.props[f];if(D(t)&&(t=t()),typeof t=="object"&&t!==null&&n in t){const i=S(t,n);return i&&!i.configurable&&(i.configurable=!0),i}}},has(e,n){if(n===N||n===G)return!1;for(let f of e.props)if(D(f)&&(f=f()),f!=null&&n in f)return!0;return!1},ownKeys(e){const n=[];for(let f of e.props){D(f)&&(f=f());for(const t in f)n.includes(t)||n.push(t)}return n}};function ye(...e){return new Proxy({props:e},_e)}function Y(e){for(var n=j,f=j;n!==null&&!(n.f&(ne|te));)n=n.parent;try{return F(n),e()}finally{F(f)}}function we(e,n,f,t){var C;var i=(f&ie)!==0,_=!ae||(f&fe)!==0,h=(f&se)!==0,P=(f&le)!==0,l=!1,r;h?[r,l]=de(()=>e[n]):r=e[n];var a=N in e||G in e,u=((C=S(e,n))==null?void 0:C.set)??(a&&h&&n in e?d=>e[n]=d:void 0),s=t,v=!0,c=!1,I=()=>(c=!0,v&&(v=!1,P?s=q(t):s=t),s);r===void 0&&t!==void 0&&(u&&_&&X(),r=I(),u&&u(r));var b;if(_)b=()=>{var d=e[n];return d===void 0?I():(v=!0,c=!1,d)};else{var E=Y(()=>(i?K:ue)(()=>e[n]));E.f|=k,b=()=>{var d=y(E);return d!==void 0&&(s=void 0),d===void 0?s:d}}if(!(f&ee))return b;if(u){var p=e.$$legacy;return function(d,R){return arguments.length>0?((!_||!R||p||l)&&u(R?b():d),d):b()}}var O=!1,B=!1,T=Z(r),A=Y(()=>K(()=>{var d=b(),R=y(T);return O?(O=!1,B=!0,R):(B=!1,T.v=d)}));return i||(A.equals=re),function(d,R){if(arguments.length>0){const x=R?y(A):_&&h?m(d):d;return A.equals(x)||(O=!0,g(T,x),c&&s!==void 0&&(s=x),q(()=>y(A))),d}return y(A)}}export{we as a,ge as b,be as c,m as p,ye as s};
