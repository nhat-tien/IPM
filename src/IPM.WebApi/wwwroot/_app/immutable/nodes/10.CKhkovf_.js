import{c as z,z as R,P as Z,Z as q}from"../chunks/PrimaryTextField.BGRG2kUX.js";import{g as W,t as G,c as J,R as K,P as j,a as Q,b as U,S as V}from"../chunks/RowToLeft.DeaIvoKE.js";import"../chunks/disclose-version.Bg9kRutz.js";import{a9 as X,a3 as Y,v,aa as ee,ab as B,a4 as g,a1 as A,a6 as y,a5 as C,t as ae,j as $,l as te}from"../chunks/runtime.CGf5uJ7Y.js";import{s as re,e as oe}from"../chunks/render.Qv6iRyJ3.js";import{c as M}from"../chunks/css-props.sBKAe1PU.js";import{e as se,i as ne}from"../chunks/each.CTzuMR3Z.js";import{a as e,t as f,b as L,c as E}from"../chunks/template.DrFoD_Dm.js";import{p as N}from"../chunks/props.CkQrhzFR.js";import{B as ie,T as le,a as de}from"../chunks/TableRow.BlxOIih7.js";import{T as me}from"../chunks/TitleWebPage.BrpKPykg.js";import{o as pe,c as ce}from"../chunks/modal.svelte.CsM8e72q.js";import{t as ve}from"../chunks/Toaster.svelte_svelte_type_style_lang.Cu0oHrnA.js";import{a as fe}from"../chunks/entry.DtVho4PG.js";async function ue(){return await W(z)}const Te=async({depends:r})=>(r("aidType:getAll"),{aidType:ue()}),He=Object.freeze(Object.defineProperty({__proto__:null,load:Te},Symbol.toStringTag,{value:"Module"}));function ge(r){return G(r,o=>[o.aidTypeId+"",o.aidTypeName])}const ye=R.object({aidTypeName:R.string().nonempty({message:"Tên loại viện trợ không để trống"})});async function _e(r){const o={aidTypeName:r.get("aidTypeName")};return await J({scheme:ye,endpoint:z,formData:o})}var $e=f("<!> <!>",1),he=f('<div class="modal"><h4> </h4> <form class="svelte-94k1qb"><svelte-css-wrapper style="display: contents"><!></svelte-css-wrapper> <!></form></div>'),be=f('<svelte-css-wrapper style="display: contents"><!></svelte-css-wrapper>',1),we=f("<div>Loading</div>"),Pe=f("<!> <!>",1),xe=f("<!> <!>",1);function Ie(r,o){X(o,!0);const F=m=>{var p=he(),a=C(p),_=C(a);ae(()=>re(_,`Thêm ${s.toLowerCase()??""}`)),y(a);var u=g(a,2),t=C(u),b=te(()=>`Tên ${s.toLowerCase()}`);M(t,()=>({"--margin-top":"1em","--margin-bottom":"1em"})),Z(t.lastChild,{id:"aidTypeName",name:"aidTypeName",type:"text",placeHolder:"",get label(){return $(b)},get error(){return $(h)},errorId:"aidTypeName",onfocus:S}),y(t);var n=g(t,2);U(n,{children:(i,c)=>{var l=$e(),d=v(l);j(d,{variant:"orange",type:"submit",children:(T,P)=>{A();var x=L("Thêm");e(T,x)},$$slots:{default:!0}});var w=g(d,2);V(w,{onclick:()=>ce(),children:(T,P)=>{A();var x=L("Hủy");e(T,x)},$$slots:{default:!0}}),e(i,l)},$$slots:{default:!0}}),y(u),y(p),oe("submit",u,I),e(m,p)};let s="Loại viện trợ",H=[`Mã ${s.toLowerCase()}`,`Tên ${s.toLowerCase()}`],h=Y(N([]));function S(){B(h,N([]))}async function I(m){m.preventDefault();const p=new FormData(m.target),a=await _e(p);a.isSuccess?(ve.success("Thêm thành công"),fe("aidType:getAll")):a.error instanceof q&&B(h,N(a.error.issues))}var k=xe(),D=v(k);me(D,{title:s});var O=g(D,2);ie(O,{header:s,breadcrumb:[s,"Danh sách"],children:(m,p)=>{var a=Pe(),_=v(a);K(_,{children:(t,b)=>{var n=be(),i=v(n);M(i,()=>({"--margin-bottom":"0.5em"})),j(i.lastChild,{onclick:()=>{S(),pe(F)},variant:"orange",children:(c,l)=>{A();var d=L("Thêm");e(c,d)},$$slots:{default:!0}}),y(i),e(t,n)},$$slots:{default:!0}});var u=g(_,2);le(u,{headers:H,children:(t,b)=>{var n=E(),i=v(n);Q(i,()=>o.data.aidType,c=>{var l=we();e(c,l)},(c,l)=>{var d=E(),w=v(d);se(w,17,()=>ge($(l)),ne,(T,P)=>{de(T,{get row(){return $(P)}})}),e(c,d)}),e(t,n)},$$slots:{default:!0}}),e(m,a)},$$slots:{default:!0}}),e(r,k),ee()}export{Ie as component,He as universal};
