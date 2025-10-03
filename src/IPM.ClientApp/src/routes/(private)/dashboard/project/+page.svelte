<script lang="ts">
  import BasicCenterLayout from "@components/Layout/BasicCenterLayout.svelte";
  import TitleWebPage from "@components/Misc/TitleWebPage.svelte";
  import type { PageData } from "./$types";
  import { goto } from "$app/navigation";
  import Row from "@components/Row/Row.svelte";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import Container from "@components/Container/Container.svelte";
  import ImageWrapper from "@components/ImageWrapper/ImageWrapper.svelte";
  import SearchBar from "@components/SearchBar/SearchBar.svelte";
    import Select from "@components/Select/Select.svelte";
    import { isStringInlucde } from "@utils/search";

  const { data }: { data: PageData } = $props();

  let header = "Dự án của tôi";

  let projectsFilter = $state(data.projects);

  let searchString = $state("");

  function handleSearch() {
    projectsFilter = data.projects.filter(e => 
      isStringInlucde(e.projectNameVietnamese, searchString))
  }
</script>

<TitleWebPage title={header} />
<BasicCenterLayout {header} breadcrumb={[header, "Danh sách"]}>
  <Row --justify-content="flex-end" >
    <PrimaryButton
      onclick={() => {
        goto("/dashboard/project/create");
      }}
      variant="orange"
      --margin-bottom="0.5em">Dự án mới</PrimaryButton
    >
  </Row >
  <Container>
    <Row --padding="1em 1em 1em 1.5em">
      <SearchBar
        bind:value={searchString}
        onenter={handleSearch}
        --width="50%"
      />
      <Select
        placeHolder={"Tìm kiếm theo ..."}
        items={[{ name: "tên dự án", value: "project-name" }]}
      />
      <Select
        placeHolder={"Sắp xếp"}
        items={[{ name: "tên dự án", value: "project-name" }]}
      />
    </Row>
    <div class="main-content">
      <ul class="project-list">
        {#each projectsFilter as project }
          <li class="project">
            <a class="flex flex-row" href={`/dashboard/project/${project.projectId}/view`}>
              <div class="project__thumbnail">
                <ImageWrapper
                  url="https://images.unsplash.com/photo-1454165804606-c3d57bc86b40"
                  alt="Hello"
                  width={150}
                  height={100}
                />
              </div>
              <div class="project__info">
                <p class="project-name-vn">{project.projectNameVietnamese}</p>
                <p class="project-name-en">{project.projectNameEnglish}</p>
                <p class="project-affiliatedUnit">{project.affiliatedUnit?.affiliatedUnitName}</p>
              </div>
            </a>
            <div class="project__action"></div>
          </li>
        {/each}
      </ul>
    </div>
    <Row --padding="1em 1em 1em 1.5em"></Row>
  </Container>
</BasicCenterLayout>

<style lang="scss">

.project-list {
  padding: 1rem;
}

.project {
  display: flex;
  flex-direction: row;
  padding: 1em;
}

.project:hover {
  background-color: var(--hover-500-clr);
}

.project:not(:is(:first-child)) {
  border-top: var(--border-500);
}

.project__info {
  margin-left: 1em;
  max-width: max-content;
  width: 500px;
}

.project-name-vn {
    font-size: 1.5rem;
    font-weight: 600;
    text-align: left;
    margin-bottom: 0.2em;
    width: max-content;
}

.project-name-en {
    text-align: left;
    font-size: 1rem;
    color: var(--text-400-clr);
    margin-bottom: 1em;
}

.project-affiliatedUnit {
    font-size: 0.8rem;
    color: var(--text-400-clr);
}

.project__thumbnail {
}

</style>
