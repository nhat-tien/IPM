import{l as st}from"./index.BFqC5wTN.js";const dt=!1;var Cn=Array.isArray,Pn=Array.from,Fn=Object.defineProperty,_t=Object.getOwnPropertyDescriptor,$t=Object.getOwnPropertyDescriptors,bn=Object.prototype,Ln=Array.prototype,Zt=Object.getPrototypeOf;function qn(t){return typeof t=="function"}const Mn=()=>{};function Hn(t){return typeof(t==null?void 0:t.then)=="function"}function Yn(t){return t()}function zt(t){for(var n=0;n<t.length;n++)t[n]()}const y=2,Et=4,Y=8,lt=16,m=32,z=64,Q=128,D=256,V=512,h=1024,I=2048,j=4096,P=8192,F=16384,Jt=32768,yt=65536,jn=1<<17,Wt=1<<19,wt=1<<20,ct=Symbol("$state"),Bn=Symbol("legacy props"),Un=Symbol("");function Tt(t){return t===this.v}function Xt(t,n){return t!=t?n==n:t!==n||t!==null&&typeof t=="object"||typeof t=="function"}function mt(t){return!Xt(t,this.v)}function Qt(t){throw new Error("https://svelte.dev/e/effect_in_teardown")}function tn(){throw new Error("https://svelte.dev/e/effect_in_unowned_derived")}function nn(t){throw new Error("https://svelte.dev/e/effect_orphan")}function rn(){throw new Error("https://svelte.dev/e/effect_update_depth_exceeded")}function Gn(){throw new Error("https://svelte.dev/e/hydration_failed")}function Vn(t){throw new Error("https://svelte.dev/e/props_invalid_value")}function Kn(){throw new Error("https://svelte.dev/e/state_descriptors_fixed")}function $n(){throw new Error("https://svelte.dev/e/state_prototype_fixed")}function en(){throw new Error("https://svelte.dev/e/state_unsafe_local_read")}function sn(){throw new Error("https://svelte.dev/e/state_unsafe_mutation")}const Zn=1,zn=2,Jn=4,Wn=8,Xn=16,Qn=1,tr=2,nr=4,rr=8,er=16,sr=4,lr=1,ar=2,ln="[",an="[!",on="]",At={},or=Symbol();function at(t,n){var r={f:0,v:t,reactions:null,equals:Tt,version:0};return r}function ur(t){return un(at(t))}function ir(t,n=!1){var e;const r=at(t);return n||(r.equals=mt),st&&f!==null&&f.l!==null&&((e=f.l).s??(e.s=[])).push(r),r}function un(t){return u!==null&&u.f&y&&(T===null?An([t]):T.push(t)),t}function fn(t,n){return u!==null&&it()&&u.f&(y|lt)&&(T===null||!T.includes(t))&&sn(),_n(t,n)}function _n(t,n){return t.equals(n)||(t.v=n,t.version=jt(),gt(t,I),it()&&o!==null&&o.f&h&&!(o.f&m)&&(v!==null&&v.includes(t)?(A(o,I),X(o)):g===null?gn([t]):g.push(t))),n}function gt(t,n){var r=t.reactions;if(r!==null)for(var e=it(),s=r.length,l=0;l<s;l++){var a=r[l],i=a.f;i&I||!e&&a===o||(A(a,n),i&(h|D)&&(i&y?gt(a,j):X(a)))}}function It(t){console.warn("https://svelte.dev/e/hydration_mismatch")}let O=!1;function fr(t){O=t}let w;function L(t){if(t===null)throw It(),At;return w=t}function _r(){return L(N(w))}function cr(t){if(O){if(N(w)!==null)throw It(),At;w=t}}function vr(t=1){if(O){for(var n=t,r=w;n--;)r=N(r);w=r}}function pr(){for(var t=0,n=w;;){if(n.nodeType===8){var r=n.data;if(r===on){if(t===0)return n;t-=1}else(r===ln||r===an)&&(t+=1)}var e=N(n);n.remove(),n=e}}var vt,Rt,St;function hr(){if(vt===void 0){vt=window;var t=Element.prototype,n=Node.prototype;Rt=_t(n,"firstChild").get,St=_t(n,"nextSibling").get,t.__click=void 0,t.__className="",t.__attributes=null,t.__styles=null,t.__e=void 0,Text.prototype.__t=void 0}}function tt(t=""){return document.createTextNode(t)}function nt(t){return Rt.call(t)}function N(t){return St.call(t)}function dr(t,n){if(!O)return nt(t);var r=nt(w);if(r===null)r=w.appendChild(tt());else if(n&&r.nodeType!==3){var e=tt();return r==null||r.before(e),L(e),e}return L(r),r}function Er(t,n){if(!O){var r=nt(t);return r instanceof Comment&&r.data===""?N(r):r}return w}function yr(t,n=1,r=!1){let e=O?w:t;for(var s;n--;)s=e,e=N(e);if(!O)return e;var l=e==null?void 0:e.nodeType;if(r&&l!==3){var a=tt();return e===null?s==null||s.after(a):e.before(a),L(a),a}return L(e),e}function wr(t){t.textContent=""}function cn(t){var n=y|I;o===null?n|=D:o.f|=wt;var r=u!==null&&u.f&y?u:null;const e={children:null,ctx:f,deps:null,equals:Tt,f:n,fn:t,reactions:null,v:null,version:0,parent:r??o};return r!==null&&(r.children??(r.children=[])).push(e),e}function Tr(t){const n=cn(t);return n.equals=mt,n}function Ot(t){var n=t.children;if(n!==null){t.children=null;for(var r=0;r<n.length;r+=1){var e=n[r];e.f&y?ot(e):x(e)}}}function vn(t){for(var n=t.parent;n!==null;){if(!(n.f&y))return n;n=n.parent}return null}function xt(t){var n,r=o;Z(vn(t));try{Ot(t),n=Bt(t)}finally{Z(r)}return n}function Dt(t){var n=xt(t),r=(S||t.f&D)&&t.deps!==null?j:h;A(t,r),t.equals(n)||(t.v=n,t.version=jt())}function ot(t){Ot(t),H(t,0),A(t,F),t.v=t.children=t.deps=t.ctx=t.reactions=null}function Nt(t){o===null&&u===null&&nn(),u!==null&&u.f&D&&tn(),ut&&Qt()}function pn(t,n){var r=n.last;r===null?n.last=n.first=t:(r.next=t,t.prev=r,n.last=t)}function b(t,n,r,e=!0){var s=(t&z)!==0,l=o,a={ctx:f,deps:null,deriveds:null,nodes_start:null,nodes_end:null,f:t|I,first:null,fn:n,last:null,next:null,parent:s?null:l,prev:null,teardown:null,transitions:null,version:0};if(r){var i=k;try{pt(!0),W(a),a.f|=Jt}catch(_){throw x(a),_}finally{pt(i)}}else n!==null&&X(a);var p=r&&a.deps===null&&a.first===null&&a.nodes_start===null&&a.teardown===null&&(a.f&wt)===0;if(!p&&!s&&e&&(l!==null&&pn(a,l),u!==null&&u.f&y)){var d=u;(d.children??(d.children=[])).push(a)}return a}function mr(t){const n=b(Y,null,!1);return A(n,h),n.teardown=t,n}function Ar(t){Nt();var n=o!==null&&(o.f&m)!==0&&f!==null&&!f.m;if(n){var r=f;(r.e??(r.e=[])).push({fn:t,effect:o,reaction:u})}else{var e=kt(t);return e}}function gr(t){return Nt(),hn(t)}function Ir(t){const n=b(z,t,!0);return(r={})=>new Promise(e=>{r.outro?yn(n,()=>{x(n),e(void 0)}):(x(n),e(void 0))})}function kt(t){return b(Et,t,!1)}function hn(t){return b(Y,t,!0)}function Rr(t){return dn(t)}function dn(t,n=0){return b(Y|lt|n,t,!0)}function Sr(t,n=!0){return b(Y|m,t,!0,n)}function Ct(t){var n=t.teardown;if(n!==null){const r=ut,e=u;ht(!0),$(null);try{n.call(null)}finally{ht(r),$(e)}}}function Pt(t){var n=t.deriveds;if(n!==null){t.deriveds=null;for(var r=0;r<n.length;r+=1)ot(n[r])}}function Ft(t,n=!1){var r=t.first;for(t.first=t.last=null;r!==null;){var e=r.next;x(r,n),r=e}}function En(t){for(var n=t.first;n!==null;){var r=n.next;n.f&m||x(n),n=r}}function x(t,n=!0){var r=!1;if((n||t.f&Wt)&&t.nodes_start!==null){for(var e=t.nodes_start,s=t.nodes_end;e!==null;){var l=e===s?null:N(e);e.remove(),e=l}r=!0}Ft(t,n&&!r),Pt(t),H(t,0),A(t,F);var a=t.transitions;if(a!==null)for(const p of a)p.stop();Ct(t);var i=t.parent;i!==null&&i.first!==null&&bt(t),t.next=t.prev=t.teardown=t.ctx=t.deps=t.fn=t.nodes_start=t.nodes_end=null}function bt(t){var n=t.parent,r=t.prev,e=t.next;r!==null&&(r.next=e),e!==null&&(e.prev=r),n!==null&&(n.first===t&&(n.first=e),n.last===t&&(n.last=r))}function yn(t,n){var r=[];Lt(t,r,!0),wn(r,()=>{x(t),n&&n()})}function wn(t,n){var r=t.length;if(r>0){var e=()=>--r||n();for(var s of t)s.out(e)}else n()}function Lt(t,n,r){if(!(t.f&P)){if(t.f^=P,t.transitions!==null)for(const a of t.transitions)(a.is_global||r)&&n.push(a);for(var e=t.first;e!==null;){var s=e.next,l=(e.f&yt)!==0||(e.f&m)!==0;Lt(e,n,l?r:!1),e=s}}}function Or(t){qt(t,!0)}function qt(t,n){if(t.f&P){B(t)&&W(t),t.f^=P;for(var r=t.first;r!==null;){var e=r.next,s=(r.f&yt)!==0||(r.f&m)!==0;qt(r,s?n:!1),r=e}if(t.transitions!==null)for(const l of t.transitions)(l.is_global||n)&&l.in()}}let K=!1,rt=[];function Mt(){K=!1;const t=rt.slice();rt=[],zt(t)}function xr(t){K||(K=!0,queueMicrotask(Mt)),rt.push(t)}function Tn(){K&&Mt()}const Ht=0,mn=1;let U=!1,G=Ht,q=!1,M=null,k=!1,ut=!1;function pt(t){k=t}function ht(t){ut=t}let R=[],C=0;let u=null;function $(t){u=t}let o=null;function Z(t){o=t}let T=null;function An(t){T=t}let v=null,E=0,g=null;function gn(t){g=t}let Yt=1,S=!1,f=null;function Dr(t){f=t}function jt(){return++Yt}function it(){return!st||f!==null&&f.l===null}function B(t){var a,i;var n=t.f;if(n&I)return!0;if(n&j){var r=t.deps,e=(n&D)!==0;if(r!==null){var s;if(n&V){for(s=0;s<r.length;s++)((a=r[s]).reactions??(a.reactions=[])).push(t);t.f^=V}for(s=0;s<r.length;s++){var l=r[s];if(B(l)&&Dt(l),e&&o!==null&&!S&&!((i=l==null?void 0:l.reactions)!=null&&i.includes(t))&&(l.reactions??(l.reactions=[])).push(t),l.version>t.version)return!0}}(!e||o!==null&&!S)&&A(t,h)}return!1}function In(t,n){for(var r=n;r!==null;){if(r.f&Q)try{r.fn(t);return}catch{r.f^=Q}r=r.parent}throw U=!1,t}function Rn(t){return(t.f&F)===0&&(t.parent===null||(t.parent.f&Q)===0)}function J(t,n,r,e){if(U){if(r===null&&(U=!1),Rn(n))throw t;return}r!==null&&(U=!0);{In(t,n);return}}function Bt(t){var ft;var n=v,r=E,e=g,s=u,l=S,a=T,i=f,p=t.f;v=null,E=0,g=null,u=p&(m|z)?null:t,S=!k&&(p&D)!==0,T=null,f=t.ctx;try{var d=(0,t.fn)(),_=t.deps;if(v!==null){var c;if(H(t,E),_!==null&&E>0)for(_.length=E+v.length,c=0;c<v.length;c++)_[E+c]=v[c];else t.deps=_=v;if(!S)for(c=E;c<_.length;c++)((ft=_[c]).reactions??(ft.reactions=[])).push(t)}else _!==null&&E<_.length&&(H(t,E),_.length=E);return d}finally{v=n,E=r,g=e,u=s,S=l,T=a,f=i}}function Sn(t,n){let r=n.reactions;if(r!==null){var e=r.indexOf(t);if(e!==-1){var s=r.length-1;s===0?r=n.reactions=null:(r[e]=r[s],r.pop())}}r===null&&n.f&y&&(v===null||!v.includes(n))&&(A(n,j),n.f&(D|V)||(n.f^=V),H(n,0))}function H(t,n){var r=t.deps;if(r!==null)for(var e=n;e<r.length;e++)Sn(t,r[e])}function W(t){var n=t.f;if(!(n&F)){A(t,h);var r=o,e=f;o=t;try{n&lt?En(t):Ft(t),Pt(t),Ct(t);var s=Bt(t);t.teardown=typeof s=="function"?s:null,t.version=Yt}catch(l){J(l,t,r,e||t.ctx)}finally{o=r}}}function Ut(){if(C>1e3){C=0;try{rn()}catch(t){if(M!==null)J(t,M,null);else throw t}}C++}function Gt(t){var n=t.length;if(n!==0){Ut();var r=k;k=!0;try{for(var e=0;e<n;e++){var s=t[e];s.f&h||(s.f^=h);var l=[];Vt(s,l),On(l)}}finally{k=r}}}function On(t){var n=t.length;if(n!==0)for(var r=0;r<n;r++){var e=t[r];if(!(e.f&(F|P)))try{B(e)&&(W(e),e.deps===null&&e.first===null&&e.nodes_start===null&&(e.teardown===null?bt(e):e.fn=null))}catch(s){J(s,e,null,e.ctx)}}}function xn(){if(q=!1,C>1001)return;const t=R;R=[],Gt(t),q||(C=0,M=null)}function X(t){G===Ht&&(q||(q=!0,queueMicrotask(xn))),M=t;for(var n=t;n.parent!==null;){n=n.parent;var r=n.f;if(r&(z|m)){if(!(r&h))return;n.f^=h}}R.push(n)}function Vt(t,n){var r=t.first,e=[];t:for(;r!==null;){var s=r.f,l=(s&m)!==0,a=l&&(s&h)!==0,i=r.next;if(!a&&!(s&P))if(s&Y){if(l)r.f^=h;else try{B(r)&&W(r)}catch(c){J(c,r,null,r.ctx)}var p=r.first;if(p!==null){r=p;continue}}else s&Et&&e.push(r);if(i===null){let c=r.parent;for(;c!==null;){if(t===c)break t;var d=c.next;if(d!==null){r=d;continue t}c=c.parent}}r=i}for(var _=0;_<e.length;_++)p=e[_],n.push(p),Vt(p,n)}function Kt(t){var n=G,r=R;try{Ut();const s=[];G=mn,R=s,q=!1,Gt(r);var e=t==null?void 0:t();return Tn(),(R.length>0||s.length>0)&&Kt(),C=0,M=null,e}finally{G=n,R=r}}async function Nr(){await Promise.resolve(),Kt()}function Dn(t){var _;var n=t.f,r=(n&y)!==0;if(r&&n&F){var e=xt(t);return ot(t),e}if(u!==null){T!==null&&T.includes(t)&&en();var s=u.deps;v===null&&s!==null&&s[E]===t?E++:v===null?v=[t]:v.push(t),g!==null&&o!==null&&o.f&h&&!(o.f&m)&&g.includes(t)&&(A(o,I),X(o))}else if(r&&t.deps===null)for(var l=t,a=l.parent,i=l;a!==null;)if(a.f&y){var p=a;i=p,a=p.parent}else{var d=a;(_=d.deriveds)!=null&&_.includes(i)||(d.deriveds??(d.deriveds=[])).push(i);break}return r&&(l=t,B(l)&&Dt(l)),t.v}function kr(t){const n=u;try{return u=null,t()}finally{u=n}}const Nn=~(I|j|h);function A(t,n){t.f=t.f&Nn|n}function Cr(t,n=1){var r=Dn(t),e=n===1?r++:r--;return fn(t,r),e}function Pr(t,n=!1,r){f={p:f,c:null,e:null,m:!1,s:t,x:null,l:null},st&&!n&&(f.l={s:null,u:null,r1:[],r2:at(!1)})}function Fr(t){const n=f;if(n!==null){const a=n.e;if(a!==null){var r=o,e=u;n.e=null;try{for(var s=0;s<a.length;s++){var l=a[s];Z(l.effect),$(l.reaction),kt(l.fn)}}finally{Z(r),$(e)}}f=n.p,n.m=!0}return{}}function br(t){if(!(typeof t!="object"||!t||t instanceof EventTarget)){if(ct in t)et(t);else if(!Array.isArray(t))for(let n in t){const r=t[n];typeof r=="object"&&r&&ct in r&&et(r)}}}function et(t,n=new Set){if(typeof t=="object"&&t!==null&&!(t instanceof EventTarget)&&!n.has(t)){n.add(t),t instanceof Date&&t.getTime();for(let e in t)try{et(t[e],n)}catch{}const r=Zt(t);if(r!==Object.prototype&&r!==Array.prototype&&r!==Map.prototype&&r!==Set.prototype&&r!==Date.prototype){const e=$t(r);for(let s in e){const l=e[s].get;if(l)try{l.call(t)}catch{}}}}}export{Ar as $,wr as A,wn as B,x as C,nt as D,yt as E,on as F,u as G,an as H,P as I,Wn as J,ir as K,at as L,Xn as M,N,mr as O,vr as P,Rr as Q,Cr as R,ct as S,ur as T,or as U,yr as V,dr as W,cr as X,Dn as Y,fn as Z,f as _,_r as a,lr as a0,ar as a1,Pr as a2,Fr as a3,Er as a4,bn as a5,Ln as a6,Kn as a7,_t as a8,$n as a9,It as aA,Gn as aB,Ir as aC,Kt as aD,gr as aE,Nr as aF,it as aG,Hn as aH,Dr as aI,Yn as aJ,br as aK,vt as aL,Zt as aa,Vn as ab,jn as ac,nr as ad,mt as ae,m as af,z as ag,Z as ah,Qn as ai,tr as aj,rr as ak,Bn as al,cn as am,Tr as an,er as ao,qn as ap,lt as aq,Jt as ar,sr as as,$ as at,Un as au,$t as av,Fn as aw,hr as ax,ln as ay,At as az,dn as b,Sr as c,w as d,kt as e,zt as f,tt as g,O as h,Jn as i,L as j,Cn as k,Pn as l,pr as m,Mn as n,fr as o,yn as p,xr as q,hn as r,Xt as s,Or as t,kr as u,o as v,Zn as w,_n as x,zn as y,Lt as z};
