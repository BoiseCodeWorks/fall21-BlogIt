<template>
  <div>
    <div class="card bg-dark text-white" v-if="blog">
      <h1>{{ blog?.title }}</h1>
      <div v-for="t in tags" :key="t.id">
        <!-- NOTE this is iteration over blogTags not tags -->
        {{ t.tag?.name }}
      </div>
    </div>

    <div class="card m-3" v-for="b in blogs" :key="b.id" @click="getBlog(b)">{{ b }}</div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState.js'
import { blogsService } from '../services/BlogsService.js'
import { onMounted } from '@vue/runtime-core'

export default {
  name: 'Home',
  setup() {

    onMounted(blogsService.get)

    return {
      blogs: computed(() => AppState.blogs),
      blog: computed(() => AppState.blog),
      tags: computed(() => AppState.tags),
      getBlog(b) {
        blogsService.getById(b.id)
        blogsService.getTagsByBlogId(b.id)
      }
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;
  .home-card {
    width: 50vw;
    > img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
