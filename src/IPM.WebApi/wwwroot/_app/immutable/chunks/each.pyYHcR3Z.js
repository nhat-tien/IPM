import{i as ee,b as ae,j as X,h as w,k as b,a as re,l as ne,m as P,H as ie,o as F,t as k,d as H,I as M,v as Q,c as W,p as fe,q as le,w as G,x as L,y as J,z as y,A as te,B as se,C as ue,f as ve,D as de,F as oe,G as _e,J as ce,K as he,L as K,M as Ee,N as pe}from"./runtime.lGjdO0kn.js";function me(l,e){return e}function Ae(l,e,a,u){for(var v=[],d=e.length,t=0;t<d;t++)te(e[t].e,v,!0);var p=d>0&&v.length===0&&a!==null;if(p){var _=a.parentNode;se(_),_.append(a),u.clear(),C(l,e[0].prev,e[d-1].next)}ue(v,()=>{for(var I=0;I<d;I++){var o=e[I];p||(u.delete(o.k),C(l,o.prev,o.next)),ve(o.e,!p)}})}function Ce(l,e,a,u,v,d=null){var t=l,p={flags:e,items:new Map,first:null},_=(e&X)!==0;if(_){var I=l;t=w?b(de(I)):I.appendChild(ee())}w&&re();var o=null,T=!1;ae(()=>{var x=a(),r=ne(x)?x:x==null?[]:P(x),i=r.length;if(T&&i===0)return;T=i===0;let s=!1;if(w){var N=t.data===ie;N!==(i===0)&&(t=F(),b(t),k(!1),s=!0)}if(w){for(var c=null,h,E=0;E<i;E++){if(H.nodeType===8&&H.data===oe){t=H,s=!0,k(!1);break}var A=r[E],n=u(A,E);h=Z(H,p,c,null,A,n,E,v,e),p.items.set(n,h),c=h}i>0&&b(F())}if(!w){var f=_e;Ie(r,p,t,v,e,(f.f&M)!==0,u)}d!==null&&(i===0?o?Q(o):o=W(()=>d(t)):o!==null&&fe(o,()=>{o=null})),s&&k(!0),a()}),w&&(t=H)}function Ie(l,e,a,u,v,d,t,p){var q,B,V,Y;var _=(v&ce)!==0,I=(v&(L|y))!==0,o=l.length,T=e.items,x=e.first,r=x,i,s=null,N,c=[],h=[],E,A,n,f;if(_)for(f=0;f<o;f+=1)E=l[f],A=t(E,f),n=T.get(A),n!==void 0&&((q=n.a)==null||q.measure(),(N??(N=new Set)).add(n));for(f=0;f<o;f+=1){if(E=l[f],A=t(E,f),n=T.get(A),n===void 0){var $=r?r.e.nodes_start:a;s=Z($,e,s,s===null?e.first:s.next,E,A,f,u,v),T.set(A,s),c=[],h=[],r=s.next;continue}if(I&&Te(n,E,f,v),n.e.f&M&&(Q(n.e),_&&((B=n.a)==null||B.unfix(),(N??(N=new Set)).delete(n))),n!==r){if(i!==void 0&&i.has(n)){if(c.length<h.length){var D=h[0],m;s=D.prev;var O=c[0],R=c[c.length-1];for(m=0;m<c.length;m+=1)U(c[m],D,a);for(m=0;m<h.length;m+=1)i.delete(h[m]);C(e,O.prev,R.next),C(e,s,O),C(e,R,D),r=D,s=R,f-=1,c=[],h=[]}else i.delete(n),U(n,r,a),C(e,n.prev,n.next),C(e,n,s===null?e.first:s.next),C(e,s,n),s=n;continue}for(c=[],h=[];r!==null&&r.k!==A;)(d||!(r.e.f&M))&&(i??(i=new Set)).add(r),h.push(r),r=r.next;if(r===null)continue;n=r}c.push(n),s=n,r=n.next}if(r!==null||i!==void 0){for(var g=i===void 0?[]:P(i);r!==null;)(d||!(r.e.f&M))&&g.push(r),r=r.next;var S=g.length;if(S>0){var j=v&X&&o===0?a:null;if(_){for(f=0;f<S;f+=1)(V=g[f].a)==null||V.measure();for(f=0;f<S;f+=1)(Y=g[f].a)==null||Y.fix()}Ae(e,g,j,T)}}_&&le(()=>{var z;if(N!==void 0)for(n of N)(z=n.a)==null||z.apply()}),G.first=e.first&&e.first.e,G.last=s&&s.e}function Te(l,e,a,u){u&L&&J(l.v,e),u&y?J(l.i,a):l.i=a}function Z(l,e,a,u,v,d,t,p,_,I){var o=(_&L)!==0,T=(_&Ee)===0,x=o?T?he(v):K(v):v,r=_&y?K(t):t,i={i:r,v:x,k:d,a:null,e:null,prev:a,next:u};try{return i.e=W(()=>p(l,x,r),w),i.e.prev=a&&a.e,i.e.next=u&&u.e,a===null?e.first=i:(a.next=i,a.e.next=i.e),u!==null&&(u.prev=i,u.e.prev=i.e),i}finally{}}function U(l,e,a){for(var u=l.next?l.next.e.nodes_start:a,v=e?e.e.nodes_start:a,d=l.e.nodes_start;d!==u;){var t=pe(d);v.before(d),d=t}}function C(l,e,a){e===null?l.first=a:(e.next=a,e.e.next=a&&a.e),a!==null&&(a.prev=e,a.e.prev=e&&e.e)}export{Ce as e,me as i};