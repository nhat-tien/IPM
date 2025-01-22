<script>
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  let header = "Dự án";
</script>

<TitleWebPage title={header} />
<BasicCenterLayout header={header} breadcrumb={[header, "Danh sách"]}>
  <div></div>
</BasicCenterLayout>
