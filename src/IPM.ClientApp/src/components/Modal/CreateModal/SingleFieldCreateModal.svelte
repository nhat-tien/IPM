<script lang="ts">
  import { invalidate } from "$app/navigation";
  import type { EventSubmitElements } from "@/shared.types";
  import PrimaryButton from "@components/Button/PrimaryButton.svelte";
  import SecondaryButton from "@components/Button/SecondaryButton.svelte";
  import RowToLeft from "@components/Row/RowToLeft.svelte";
  import PrimaryTextField from "@components/TextField/PrimaryTextField.svelte";
  import { invalidateCache } from "@stores/cache.svelte";
  import { closeModal } from "@stores/modal.svelte";
  import type { UseCaseResult } from "@useCases/useCases.types";
  import toast from "svelte-5-french-toast";
  import { ZodError, type ZodIssue } from "zod";

  let error: ZodIssue[] = $state([]);

  const {
    createFn,
    title,
    label,
    fieldName,
    successMessage,
    invalidateStr,
    invalidateCacheStr,
    placeHolder = "",
  }: {
    title: string;
    label: string;
    fieldName: string;
    placeHolder?: string;
    successMessage: string;
    invalidateStr?: string;
    invalidateCacheStr?: string;
    createFn: (formData: FormData) => Promise<UseCaseResult>;
  } = $props();

  async function onCreate(e: EventSubmitElements) {
    e.preventDefault();

    const formData = new FormData(e.target as HTMLFormElement);
    const result = await createFn(formData);

    if (result.isSuccess) {
      toast.success(successMessage);

      if (invalidateStr) {
        invalidate(invalidateStr);
      }
      if (invalidateCacheStr) {
        invalidateCache(invalidateCacheStr);
      }
    } else {
      if (result.error instanceof ZodError) {
        error = result.error.issues;
      }
    }
  }

  function clearError() {
    error = [];
  }
</script>

<div class="modal">
  <h3>{title}</h3>
  <form onsubmit={onCreate}>
    <PrimaryTextField
      id={fieldName}
      name={fieldName}
      type="text"
      {placeHolder}
      {label}
      --margin-top="2em"
      --margin-bottom="2em"
      {error}
      required
      errorId={fieldName}
      onfocus={clearError}
    ></PrimaryTextField>
    <RowToLeft --margin-bottom="0">
      <PrimaryButton variant="orange" type="submit">Thêm</PrimaryButton>
      <SecondaryButton onclick={() => closeModal()}>Hủy</SecondaryButton>
    </RowToLeft>
  </form>
</div>
