import"../chunks/disclose-version.Bg9kRutz.js";import{a9 as $,v as j,aa as z,a5 as _,j as d,a3 as k,ab as i,a4 as l,a6 as f,t as F,a1 as x}from"../chunks/runtime.CGf5uJ7Y.js";import{e as H,s as U}from"../chunks/render.Qv6iRyJ3.js";import{i as D}from"../chunks/if.Ci8_EKmB.js";import{c as W}from"../chunks/css-props.sBKAe1PU.js";import{a as u,t as q,b as P}from"../chunks/template.DrFoD_Dm.js";import{p as B}from"../chunks/props.CkQrhzFR.js";import{g as C}from"../chunks/entry.DtVho4PG.js";import{z as g,a as I,H as A,P as J}from"../chunks/PrimaryTextField.BGRG2kUX.js";import{s as Q}from"../chunks/jwtService.BpeZ_aWj.js";import{s as G,d as K}from"../chunks/logoutUseCase.KC4LfHll.js";import{P as M,L as N}from"../chunks/PasswordTextField.DhsZp9_g.js";import{T as O}from"../chunks/TitleWebPage.BrpKPykg.js";import{t as R}from"../chunks/Toaster.svelte_svelte_type_style_lang.Cu0oHrnA.js";const V=g.object({email:g.string().email({message:"Định dạng email chưa đúng"}),password:g.string()});async function X(m){try{let e=V.parse(m);const a=await I.post("login",{json:{email:e.email,password:e.password},credentials:"include"}).json();return G(K(a.accessToken)),Q(a.accessToken),{isSuccess:!0,error:null}}catch(e){return e instanceof A&&e.response.status==401?{isSuccess:!1,error:"Unauthorized"}:{isSuccess:!1,error:e}}}var Y=q('<!> <h1 class="svelte-11mappv">Welcome Back</h1> <form class="svelte-11mappv"><svelte-css-wrapper style="display: contents"><!></svelte-css-wrapper> <!> <a class="forgot-password svelte-11mappv" href="/">Quên mật khẩu</a> <div class="error svelte-11mappv"><!></div> <!></form> <p class="register svelte-11mappv">Chưa có tài khoản? <a href="/register" class="svelte-11mappv">Đăng kí</a></p>',1);function fe(m,e){$(e,!0);let a=k(!1),t=k(null);async function T(s){s.preventDefault(),i(a,!0);const r=new FormData(s.target),o=await X({email:r.get("email"),password:r.get("password")});if(i(a,!1),o.isSuccess)R.success("Đăng nhập thành công"),C("/dashboard");else if(o.error==="Unauthorized")i(t,"Email hoặc mật khẩu không chính xác");else{let L=o.error;i(t,B(L.issues[0].message))}}function v(){i(t,null)}var h=Y(),w=j(h);O(w,{title:"Đăng nhập"});var p=l(w,4),n=_(p);W(n,()=>({"--margin-bottom":"1.5em"})),J(n.lastChild,{id:"email",placeHolder:"anh@gmail.com",label:"Email",type:"email",name:"email",onfocus:v,required:!0}),f(n);var b=l(n,2);M(b,{id:"password",label:"Password",name:"password",placeHolder:"Password",onfocus:v,required:!0});var c=l(b,4),y=_(c);{var E=s=>{var r=P();F(()=>U(r,d(t))),u(s,r)};D(y,s=>{d(t)!=null&&s(E)})}f(c);var S=l(c,2);N(S,{get isLoading(){return d(a)},type:"submit",children:(s,r)=>{x();var o=P("Đăng nhập");u(s,o)},$$slots:{default:!0}}),f(p),x(2),H("submit",p,T),u(m,h),z()}export{fe as component};
